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
                client.BaseAddress = new Uri("https://jbzdy.cc");
                
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("l_email", user),
                    new KeyValuePair<string, string>("l_password", password)
                });

                var result = client.PostAsync("/logowanie", content).Result;

                var html = Helper.LoadHtmlDocument(client.GetAsync("/nsfw/"+ page).Result.Content.ReadAsStringAsync().Result);

                ParseContent(rezult, html);

                return rezult;

            }
        }

        internal Page Parse(int page)
        {
            var rezult = new Page(page);

            var html = Helper.LoadHtml(domainUrl + "str/" + page);
            ParseContent(rezult, html);
            return rezult;
        }

        private void ParseContent(Page rezult, HtmlAgilityPack.HtmlDocument html)
        {
            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"article-content\"]"))
            {
                var title = htmlNode.SelectSingleNode("h3[@class=\"article-title\"]")?.InnerText.TrimEnd().TrimStart();

                var url = htmlNode.SelectSingleNode("h3[@class=\"article-title\"]/a")?.Attributes["href"].Value?.ToString();

                var imgUrl = htmlNode.SelectSingleNode("div[@class=\"article-container\"]/div[@class=\"article-image\"]/a/img")?.Attributes["src"].Value?.ToString();

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
