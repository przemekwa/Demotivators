using JbzdyApi.Models;

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

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"content-info\"]"))
            {
                var title = htmlNode.SelectSingleNode("div/a")?.InnerText.TrimEnd().TrimStart();

                var url = htmlNode.SelectSingleNode("div/div/a")?.Attributes["href"].Value?.ToString();

                var imgUrl = htmlNode.SelectSingleNode("div/div/a/img")?.Attributes["src"].Value?.ToString();

                rezult.JbzdyModels.Add(new JbzdyModel
                {
                    Title = title,
                    Url = url,
                    ImgUrl = imgUrl
                });
            }
            return rezult;
        }
    }
}
