using System;
using System.Collections.Generic;

using HtmlAgilityPack;
using DemotivatorApi.Buldiers;
using DemotivatorApi.Models;

namespace DemotivatorApi.Parsers
{
    public class DemotivatorSlideParser : IParser<DemotivatorSlide>
    {
        private readonly Builder<DemotivatorSlide> buldier;

        public DemotivatorSlideParser(Builder<DemotivatorSlide> slideBuilder)
        {
            if (slideBuilder == null)
            {
                throw new ArgumentNullException(nameof(slideBuilder));
            }

            this.buldier = slideBuilder;
        }

        public IEnumerable<DemotivatorSlide> Parse(HtmlNode htmlNode)
        {
           


            //var imgTag = htmlNode.SelectSingleNode("div[@class=\"relative\"]/img[@class=\"rsImg \"]");

            //var imgDescription = htmlNode.SelectSingleNode("p");

            //if (string.IsNullOrEmpty(imgDescription?.InnerText))
            //{
            //    imgDescription = htmlNode.SelectSingleNode("h3");
            //}

            //if (imgTag == null) return null;

            //buldier.ImgUrl = imgTag.Attributes["src"].Value;

            //buldier.Description = imgDescription == null ? "" : imgDescription.InnerText;

            return null;
        }

        public IEnumerable<DemotivatorSlide> ParseMany(HtmlNode htmllNode)
        {

            //var last = htmllNode.InnerText.LastIndexOf("var MMG = MMG || {};");

            //var teskt =  htmllNode.InnerText.Substring(145,last - 145);

            // var htmlDocument = new HtmlWeb
            //{
            //    AutoDetectEncoding = true
            //};

            //var test = htmllNode.SelectNodes("//div[@class=\"pic_royal_off_single\"]");










            //throw new NotImplementedException();

            return new List<DemotivatorSlide>();
        }

        DemotivatorSlide IParser<DemotivatorSlide>.Parse(HtmlNode htmllNode)
        {
            throw new NotImplementedException();
        }
    }
}
