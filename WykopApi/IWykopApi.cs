using System;
using System.Collections.Generic;
using System.Text;
using WykopApi.Models;

namespace WykopApi
{
    public interface IWykopApi
    {
        Page GetMainPage(string tags);
        Page GetPage(int page);
        Page GetPageWithLogin(string user, string password, int page);
    }
}
