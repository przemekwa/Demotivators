using JbzdyApi;
using JbzdyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.ControllersLogic
{
    public class JbzdyLogic : IJbzdyLogic
    {
        private readonly IJbzdyApi jbzdyApi;

        public JbzdyLogic(IJbzdyApi jbzdyApi)
        {
            this.jbzdyApi = jbzdyApi;
        }

       public Page GetPage(int page) => this.jbzdyApi.GetPage(page);

        public Page GetMainPage() => this.jbzdyApi.GetPage(1);

        public Page GetPageWithLogin(string user, string password, int page) => this.jbzdyApi.GetPageWithLogin(user, password, page);
    }
}
