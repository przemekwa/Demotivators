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

        [Fact]
        public void Add_2_Tests()
        {
            var logic = new FavouriteLogic();

            logic.DeleteUser("Test");

            DemotivatorWebApi.Models.FavouriteModel model = new DemotivatorWebApi.Models.FavouriteModel
            {
                Url = "link",
                Title = "title"
            };

            DemotivatorWebApi.Models.FavouriteModel model1 = new DemotivatorWebApi.Models.FavouriteModel
            {
                Url = "link1",
                Title = "title1"
            };

            logic.Add("Test", model);
            logic.Add("Test", model1);


            var result = logic.Get("Test");

            Assert.NotNull(result);

            Assert.Equal(model.Title, result.First().Title);
            Assert.Equal(model.Url, result.First().Url);

            Assert.Equal(model1.Title, result.Last().Title);
            Assert.Equal(model1.Url, result.Last().Url);
        }

        [Fact]
        public void Delete_Tests()
        {
            var logic = new FavouriteLogic();

            logic.DeleteUser("Test");

            DemotivatorWebApi.Models.FavouriteModel model = new DemotivatorWebApi.Models.FavouriteModel
            {
                Url = "link",
                Title = "title"
            };

            DemotivatorWebApi.Models.FavouriteModel model1 = new DemotivatorWebApi.Models.FavouriteModel
            {
                Url = "link1",
                Title = "title1"
            };

            logic.Add("Test", model);
            logic.Add("Test", model1);


            var result = logic.Get("Test");

            Assert.NotNull(result);

            Assert.Equal(model.Title, result.First().Title);
            Assert.Equal(model.Url, result.First().Url);

            Assert.Equal(model1.Title, result.Last().Title);
            Assert.Equal(model1.Url, result.Last().Url);


            logic.Delete("Test", result.First().Id);

            var resultAfterDelete = logic.Get("Test").SingleOrDefault();

            Assert.NotNull(resultAfterDelete);

            Assert.Equal(model1.Title, resultAfterDelete.Title);
            Assert.Equal(model1.Url, resultAfterDelete.Url);
            Assert.False(resultAfterDelete.IsDeleted);

            var all = logic.GetAll("Test");


            Assert.NotNull(all);

            Assert.Equal(2, all.Count());



        }
    }
}
