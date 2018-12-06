using DemotivatorApi.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemotivatorApi.Parsers
{
    public class DemotivatorVideoParser : IParser<DemotivatorVideo>
    {
        private readonly string url;

        public DemotivatorVideoParser(string url)
        {
            this.url = url;
        }

        public DemotivatorVideo Parse(HtmlNode htmllNode)
        {
            if (htmllNode == null)
            {
                throw new ArgumentNullException(nameof(htmllNode));
            }

            var link = htmllNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

            var imgTag = link?.SelectSingleNode("img");

            if (imgTag == null)
            {
                return null;
            }

            var node =  htmllNode.SelectSingleNode("div/div/video");

            return new DemotivatorVideo
            {
                ImgUrl = imgTag.Attributes["src"].Value,
                Url= url + link.Attributes["href"].Value,
                
                VideoUrl = node.SelectSingleNode("source").Attributes["src"].Value
            };
        }

        public IEnumerable<DemotivatorVideo> ParseMany(HtmlNode htmllNode)
        {
            throw new NotImplementedException();
        }
    }
}
