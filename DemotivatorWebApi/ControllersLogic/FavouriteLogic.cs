﻿using DemotivatorWebApi.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.ControllersLogic
{
    public class FavouriteLogic
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

        public void Delete(string userName, FavouriteModel model)
        {

        }

        public void DeleteUser(string userName)
        {
            File.Delete($"{userName}.db");
        }
    }
}