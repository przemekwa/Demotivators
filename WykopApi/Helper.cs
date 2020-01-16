using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WykopApi
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

        public static HtmlDocument LoadHtmlDocument(string contentHtml)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(contentHtml);
            
            return htmlDocument;
        }

       
    }
}
