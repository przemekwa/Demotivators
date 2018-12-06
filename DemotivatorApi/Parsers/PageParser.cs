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
        private readonly IParser<DemotivatorVideo> demotivatorVideoParser;

        private readonly string domainUrl;

        public PageParser(IParser<Demotivator> demotivatorParser, IParser<DemotivatorSlide> slideDemotivatorParser, IParser<DemotivatorVideo> demotivatorVideoParser, string domainUrl)
        {
            this.demotivatorParser = demotivatorParser;
            this.slideDemotivatorParser = slideDemotivatorParser;
            this.demotivatorVideoParser = demotivatorVideoParser;
            this.domainUrl = domainUrl;
        }

        public Page Parse(int pageNumber)
        {
            var rezult = new Page(pageNumber);

            var html = Helper.LoadHtml(domainUrl + "page/" + pageNumber);

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var isSlideType = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                var isVideo = htmlNode.SelectNodes("div/div/video");

                if (isVideo != null)
                {
                    rezult.DemotivatorVideoCollection.Add(demotivatorVideoParser.Parse(htmlNode));
                }
                else if (isSlideType)
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
