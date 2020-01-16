using WykopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WykopApi;

namespace DemotivatorWebApi.ControllersLogic
{
    public class WykopLogic : IWykopLogic
    {
        private readonly IWykopApi wykopApi;

        public WykopLogic(IWykopApi wykopApi)
        {
            this.wykopApi = wykopApi;
        }

        public Page GetMainPage(string tags)
        {
            return this.wykopApi.GetMainPage(tags);
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
