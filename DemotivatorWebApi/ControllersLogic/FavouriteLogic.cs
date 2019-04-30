using DemotivatorWebApi.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.ControllersLogic
{
    public class FavouriteLogic : IFavouriteLogic
    {
        public IEnumerable<FavouriteModel> Get(string userName)
        {
            using (var db = new LiteDatabase($"{userName}.db"))
            {
                return db.GetCollection<FavouriteModel>("favourite").Find(Query.EQ("IsDeleted", false));
            }
        }

        public IEnumerable<FavouriteModel> GetAll(string userName)
        {
            using (var db = new LiteDatabase($"{userName}.db"))
            {
                return db.GetCollection<FavouriteModel>("favourite").FindAll();
            }
        }

        public void Add(string userName, FavouriteModel model)
        {
            using (var db = new LiteDatabase($"{userName}.db"))
            {
                var col = db.GetCollection<FavouriteModel>("favourite");

                model.UpdateDate = DateTime.Now;

                col.Insert(model);
            }
        }

        public void Delete(string userName, int id)
        {
            if (File.Exists($"{userName}.db") == false)
            {
                return;
            }

            using (var db = new LiteDatabase($"{userName}.db"))
            {
                var model = db.GetCollection<FavouriteModel>("favourite").FindById(id);

                if (model == null)
                {
                    return;
                }

                var col = db.GetCollection<FavouriteModel>("favourite");

                if (col == null)
                {
                    return;
                }

                model.IsDeleted = true;

                model.UpdateDate = DateTime.Now;

                col.Update(model);
            }
        }

        public void DeleteUser(string userName)
        {
            File.Delete($"{userName}.db");
        }
    }
}
