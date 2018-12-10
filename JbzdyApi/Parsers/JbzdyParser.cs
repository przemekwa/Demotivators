using JbzdyApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JbzdyApi.Parsers
{
    public class JbzdyParser
    {
        private readonly string domainUrl;

        public JbzdyParser(string domainUrl)
        {
            this.domainUrl = domainUrl;
        }

        internal Page Parse(int page)
        {
           var rezult = new Page(page);

            var html = Helper.LoadHtml(domainUrl + "strona/" + page);

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"image rolled\"]"))
            {

                rezult.JbzdyModels.Add(new JbzdyModel
                {
                    Url = htmlNode.SelectSingleNode("a").Attributes["href"].Value
                    .ToString(),
                    ImgUrl = htmlNode.SelectSingleNode("a/img").Attributes["src"].Value?.ToString()
                });

            }



            return rezult;

        }
    }
}
