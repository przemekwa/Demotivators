using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JbzdyApi
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
