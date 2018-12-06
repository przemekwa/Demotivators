using System;
using Xunit;
using DemotivatorApi;
using System.Linq;
using DemotivatorApi.Parsers;
using DemotivatorApi.Buldiers;

namespace DemotivatorApiTests
{
    public class DemotivatorApiTests
    {
       public virtual DemotivatorApi.DemotivatorApi DemotivatorApi { get; set; } = new DemotivatorApi.DemotivatorApi("http://demotywatory.pl/");

        [Fact]
        public void Get_Demot_From_Main_Page()
        {
            var rezult = DemotivatorApi.GetMainPage();

            Assert.Equal(2, rezult.DemotivatorCollection.Count);
        }

      [Fact]
        public void Get_Demot_From_First_Page()
        {
            var rezult = this.DemotivatorApi.GetPage(2);

            Assert.Equal(2, rezult.DemotivatorCollection.Count);
        }

      [Fact]
        public void Get_Slide_Demot()
        {
            var pageParser = new PageParser(null, new DemotivatorSlideParser(new DemotivatorSlideBuilder()),null, null);

            var result =
                pageParser.GetDemovivatorSlides(
                    "http://demotywatory.pl/4405857/10-ciekawostek-o-ludzkim-organizmie-ktore-cie-zadziwia");
                    

            Assert.Equal(9, result.ToList().Count);
        }


        [Fact]
        public void Get_Range_Of_Pages()
        {
            var rezult = this.DemotivatorApi.GetPages(1, 2);

            Assert.Equal(2, rezult.Count());
        }

       [Fact]
        public void Get_Demotivator_Img_Url()
        {
            var rezult = this.DemotivatorApi.GetMainPage().DemotivatorCollection;

            Assert.True(rezult.All(demot => !string.IsNullOrEmpty(demot.ImgUrl)));
        }

        [Fact]
        public void Get_Demotivator_Url()
        {
            var rezult = this.DemotivatorApi.GetMainPage().DemotivatorCollection;

            Assert.True(rezult.All(demot => !string.IsNullOrEmpty(demot.Url)));
        }

    }
}
