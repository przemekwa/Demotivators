using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WykopApi.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace WykopApi.Parsers
{
    public class WykopParser
    {
        private readonly string domainUrl;

        public WykopParser(string domainUrl)
        {
            this.domainUrl = domainUrl;
        }

        internal Page Parse(int page, IEnumerable<string> tagsName)
        {
            var pageList = new List<Page>();

            foreach (var tagName in tagsName)
            {
                var html = Helper.LoadHtml(domainUrl + $"tag/{tagName}/");
                
                var tagResult = new Page(page);

                ParseContent(tagResult, html);

                pageList.Add(tagResult);
            }

            var result = new Page(0)
            {
                WykopModels = pageList.SelectMany(s => s.WykopModels).Where(s=>s.Url.Length > 10).DistinctBy(model => model.ImgUrl).ToList()
            };

            return result;
        }

        private void ParseContent(Page rezult, HtmlAgilityPack.HtmlDocument html)
        {
            
            foreach (var htmlNode in html.DocumentNode.SelectNodes("//li[@class=\"entry iC \"]"))
            {
                var title = this.RemoveCharacters(htmlNode.SelectSingleNode("div/div/div[@class=\"text \"]/p")?.InnerText);

                var url = htmlNode.SelectSingleNode("div/div/div[@class=\"text \"]/div/a")?.Attributes["href"].Value?.ToString();

                var imgUrl = htmlNode.SelectSingleNode("div/div/div[@class=\"text \"]/div/a")?.Attributes["href"].Value?.ToString();

                if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(imgUrl))
                {
                    continue;
                }

                rezult.WykopModels.Add(new WykopModel
                {
                    Title = title,
                    Url = url,
                    ImgUrl = imgUrl
                });
            }
        }

        private string RemoveCharacters(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }

            var pattern = "#[a-zA-Z0-9]*|\t\n";

            return Regex.Replace(title, pattern,string.Empty).Trim();
        }
    }
}
