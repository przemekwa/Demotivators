using DemotivatorWebApi.ControllersLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DemotivatorApiTests
{
    public class FavouriteLogicTests
    {
        [Fact]
        public void Add_1_Tests()
        {
            var logic = new FavouriteLogic();

            logic.DeleteUser("Test");

            DemotivatorWebApi.Models.FavouriteModel model = new DemotivatorWebApi.Models.FavouriteModel
            {
                Url = "link",
                Title = "title"
            };

            logic.Add("Test", model);


            var result = logic.Get("Test").SingleOrDefault();

            Assert.NotNull(result);

            Assert.Equal(model.Title, result.Title);
            Assert.Equal(model.Url, result.Url);
        }
    }
}
