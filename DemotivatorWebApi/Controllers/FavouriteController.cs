using DemotivatorWebApi.ControllersLogic;
using DemotivatorWebApi.Models;
using DemotivatorWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public void Add([FromBody]FavouriteAddViewModel favouriteAddViewModel)
        {
            if(favouriteAddViewModel == null || favouriteAddViewModel.FavouriteModel == null || string.IsNullOrEmpty(favouriteAddViewModel.UserName))
            {
                return;
            }

           this.FavouriteLogic.Add(favouriteAddViewModel.UserName, favouriteAddViewModel.FavouriteModel);
        }
    }
}
