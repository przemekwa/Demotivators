using JbzdyApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace JbzdyApi.Parsers
{
    public class JbzdyParser
    {
        private readonly string domainUrl;

        public JbzdyParser(string domainUrl)
        {
            this.domainUrl = domainUrl;
        }

        internal Page ParseWithLogin(string user, string password, int page)
        {
            var rezult = new Page(page);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jbzdy.eu");
                
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("l_email", user),
                    new KeyValuePair<string, string>("l_password", password)
                });

                var result = client.PostAsync("/logowanie", content).Result;

                var html = Helper.LoadHtmlDocument(client.GetAsync("/nsfw").Result.Content.ReadAsStringAsync().Result);

                ParseContent(rezult, html);

                return rezult;

            }
        }

        internal Page Parse(int page)
        {
            var rezult = new Page(page);

            var html = Helper.LoadHtml(domainUrl + "strona/" + page);
            ParseContent(rezult, html);
            return rezult;
        }

        private void ParseContent(Page rezult, HtmlAgilityPack.HtmlDocument html)
        {
            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"content-info\"]"))
            {
                var title = htmlNode.SelectSingleNode("div/a")?.InnerText.TrimEnd().TrimStart();

                var url = htmlNode.SelectSingleNode("div[@class=\"media\"]/div[@class=\"image rolled\"]/a")?.Attributes["href"].Value?.ToString();

                var imgUrl = htmlNode.SelectSingleNode("div/div/a/img")?.Attributes["src"].Value?.ToString();

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(imgUrl))
                {
                    continue;
                }

                rezult.JbzdyModels.Add(new JbzdyModel
                {
                    Title = title,
                    Url = url,
                    ImgUrl = imgUrl
                });
            }
        }
    }
}
