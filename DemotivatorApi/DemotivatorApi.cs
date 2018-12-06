using System;
using System.Collections.Generic;
using System.Text;

namespace DemotivatorApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;
    using Buldiers;
    using Interface;
    using Models;
    using Parsers;

    public class DemotivatorApi : IDemotivatorApi
    {
        public IPageParser PageParser { get; set; }

        public DemotivatorApi(string domainUrl)
        {
            if (string.IsNullOrEmpty(domainUrl))
            {
                throw new ArgumentNullException(nameof(domainUrl), "Adres strony demotywatorów nie może być pusty");
            }

            var demotivatorParser = new DemotivatorParser(new DemotivatorBuilder(), domainUrl);

            var slideDemotivatorParser = new DemotivatorSlideParser(new DemotivatorSlideBuilder());
            
            var videoDemotivatorParser = new DemotivatorVideoParser(domainUrl);

            this.PageParser = new PageParser(demotivatorParser, slideDemotivatorParser,videoDemotivatorParser, domainUrl);
        }

        public IEnumerable<Page> GetPages(int first, int last)
        {
            var rezult = new List<Page>();

            for (var i = first; i <= last; i++)
            {
                rezult.Add(this.PageParser.Parse(i));
            }

            return rezult;
        }

        public Page GetPage(int page)
        {
            return this.PageParser.Parse(page);
        }

        public Page GetMainPage()
        {
            return this.PageParser.Parse(1);
        }
    }
}
