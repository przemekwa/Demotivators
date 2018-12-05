using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemotivatorApi.Models;


namespace DemotivatorApi.Parsers
{
    public class PageParser : IPageParser
    {
        private readonly IParser<Demotivator> demotivatorParser;

        private readonly IParser<DemotivatorSlide> slideDemotivatorParser;

        private readonly string domainUrl;

        public PageParser(IParser<Demotivator> demotivatorParser, IParser<DemotivatorSlide> slideDemotivatorParser, string domainUrl)
        {
            this.demotivatorParser = demotivatorParser;
            this.slideDemotivatorParser = slideDemotivatorParser;
            this.domainUrl = domainUrl;
        }

        public Page Parse(int pageNumber)
        {
            var rezult = new Page(pageNumber);

            var html = Helper.LoadHtml(domainUrl + "page/" + pageNumber);

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var isSlideType = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                if (isSlideType)
                {
                    var link = htmlNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

                    var url = domainUrl + link.Attributes["href"].Value;

                    var htmlSlide = Helper.LoadHtml(url);

                    var node = htmlSlide.DocumentNode.SelectSingleNode("//div[@class=\"demotivator pic\"]");

                    rezult.DemotivatorSlideCollection.AddRange(this.slideDemotivatorParser.ParseMany(node));
                }
                else
                {
                    var demotivator = this.demotivatorParser.Parse(htmlNode);

                    if (demotivator == null)
                    {
                        continue;
                    }

                    if (demotivator.ImgUrl.Contains("demotywatoryfb") == false)
                    {
                        continue;
                    }

                    rezult.DemotivatorCollection.Add(demotivator);
                }
            }

            return rezult;
        }

        public IEnumerable<DemotivatorSlide> GetDemovivatorSlides(string url)
        {
            return new List<DemotivatorSlide>();

            //driver.Url = url;

            //driver.Navigate();

            //var pathElements = driver.FindElementsByClassName("rsImg");
            //var result = new List<DemotivatorSlide>();

            //foreach (var element in pathElements)
            //{
            //    var imgSrc = element.GetAttribute("src");

            //    if (imgSrc == null)
            //    {
            //        continue;
            //    }

            //    result.Add(new DemotivatorSlide
            //    {
            //        ImgUrl = imgSrc,
            //        Description = "",
            //        Url = url
            //    });
            //}

            //return result;
        }
    }
}
