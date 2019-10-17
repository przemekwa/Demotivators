using JbzdyApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DemotivatorApiTests
{
    public class JbzdyTests
    {
        public virtual JbzdyApi.IJbzdyApi JbzdyApi { get; set; } = new JbzdyApi.JbzdyApi("https://jbzdy.pl/");

        [Fact]
        public void GetFromMainPage()
        {
           var result= JbzdyApi.GetMainPage();

            Assert.Equal(7, result.JbzdyModels.Count);
        }

        [Fact]
        public void GetFromSecondPage()
        {
           var result= JbzdyApi.GetPage(2);

            Assert.Equal(8, result.JbzdyModels.Count);
        }

         [Fact]
        public void GetPageData()
        {
           var result= JbzdyApi.GetPage(1);

            Assert.NotEmpty(result.JbzdyModels);

            var first = result.JbzdyModels.First();

            Assert.NotEmpty(first.Title);
            Assert.NotEmpty(first.ImgUrl);
            Assert.NotEmpty(first.Url);
            
        }
    }
}
