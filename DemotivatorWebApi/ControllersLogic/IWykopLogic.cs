
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WykopApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public interface IWykopLogic
    {
        Page GetMainPage(string tags);
        Page GetPage(int page);
        Page GetPageWithLogin(string user, string password, int page);
    }
}
