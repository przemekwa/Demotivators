using System.Collections.Generic;
using DemotivatorWebApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public interface IFavouriteLogic
    {
        void Add(string userName, FavouriteModel model);
        void Delete(string userName, int id);
        void DeleteUser(string userName);
        IEnumerable<FavouriteModel> Get(string userName);
        IEnumerable<FavouriteModel> GetAll(string userName);
    }
}