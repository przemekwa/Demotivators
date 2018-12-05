using HtmlAgilityPack;
using DemotivatorApi.Buldiers;
using DemotivatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemotivatorApi.Parsers;

namespace DemotivatorApi
{
    public static class Helper
    {
        public static HtmlDocument LoadHtml(string addres)
        {
            var htmlDocument = new HtmlWeb
            {
                AutoDetectEncoding = true
            };
            
            return htmlDocument.Load(addres);
        }

       
    }
}
