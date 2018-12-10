using JbzdyApi.Models;
using JbzdyApi.Parsers;
using System;

namespace JbzdyApi
{
    public class JbzdyApi : IJbzdyApi
    {
        public JbzdyParser JbzdyParser { get; set; }

        public JbzdyApi(string domainUrl)
        {
            JbzdyParser = new JbzdyParser(domainUrl);
        }

        public Page GetPage(int page)
        {
            return this.JbzdyParser.Parse(page);
        }

        public Page GetMainPage()
        {
            return this.JbzdyParser.Parse(1);
        }
    }
}
