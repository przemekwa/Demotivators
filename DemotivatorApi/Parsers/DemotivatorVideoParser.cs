using DemotivatorApi.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemotivatorApi.Parsers
{
    public class DemotivatorVideoParser : IParser<DemotivatorVideo>
    {
        public DemotivatorVideo Parse(HtmlNode htmlNode)
        {
            var node =  htmlNode.SelectSingleNode("div/div/video");


            return new DemotivatorVideo
            {
                VideoUrl = node.SelectSingleNode("source").Attributes["src"].Value
            };
        }

        public IEnumerable<DemotivatorVideo> ParseMany(HtmlNode htmllNode)
        {
            throw new NotImplementedException();
        }
    }
}
