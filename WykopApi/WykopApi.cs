using System;
using System.Collections.Generic;
using System.Linq;
using WykopApi.Models;
using WykopApi.Parsers;

namespace WykopApi
{
    public class WykopApi : IWykopApi
    {
        public Page GetMainPage(string tags)
        {
            var tagsNames = new List<string>();

            if (string.IsNullOrEmpty(tags))
            {
                tagsNames.Add("ladnapani");
                //tagsNames.Add("ladnapani");
                //tagsNames.Add("ladnadziewczyna");
                //tagsNames.Add("bieliznaboners");
            }
            else
            {
                tagsNames = tags.Split(',').ToList();
            }

            return new WykopParser("https://www.wykop.pl/").Parse(0, tagsNames);
        }

        public Page GetPage(int page)
        {
            throw new NotImplementedException();
        }

        public Page GetPageWithLogin(string user, string password, int page)
        {
            throw new NotImplementedException();
        }
    }
}
