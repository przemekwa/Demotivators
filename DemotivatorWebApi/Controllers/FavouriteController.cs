using DemotivatorWebApi.ControllersLogic;
using DemotivatorWebApi.Models;
using DemotivatorWebApi.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemotivatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FavouriteController : ControllerBase
    {
        public IFavouriteLogic FavouriteLogic { get; set; }

        public FavouriteController(IFavouriteLogic favouriteLogic)
        {
            FavouriteLogic = favouriteLogic;
        }

        [HttpGet("{userName}")]
        public IEnumerable<FavouriteModel> Get(string userName)
        {
           return this.FavouriteLogic.Get(userName);
        }

        [HttpGet("{userName}/all")]
        public IEnumerable<FavouriteModel> GetAll(string userName)
        {
            return this.FavouriteLogic.GetAll(userName);
        }

        [HttpPost]
        public void Add([FromBody]FavouriteAddViewModel favouriteAddViewModel)
        {
            if(favouriteAddViewModel == null || favouriteAddViewModel.FavouriteModel == null || string.IsNullOrEmpty(favouriteAddViewModel.UserName))
            {
                return;
            }

           this.FavouriteLogic.Add(favouriteAddViewModel.UserName, favouriteAddViewModel.FavouriteModel);
        }

        [HttpPost("delete")]
        public void Delete([FromBody]FavouriteDeleteViewModel favouriteDeleteViewModel)
        {
            if (favouriteDeleteViewModel == null || string.IsNullOrEmpty(favouriteDeleteViewModel.UserName))
            {
                return;
            }

            this.FavouriteLogic.Delete(favouriteDeleteViewModel.UserName, favouriteDeleteViewModel.Id);
        }
    }
}
