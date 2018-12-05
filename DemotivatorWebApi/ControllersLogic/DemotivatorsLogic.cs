using DemotivatorApi.Interface;
using DemotivatorApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public class DemotivatorsLogic : IDemotivatorsLogic
    {
        private readonly IDemotivatorApi demotivatorApi;

        public DemotivatorsLogic(IDemotivatorApi demotivatorApi)
        {
            this.demotivatorApi = demotivatorApi;
        }

        public Page GetPage(int page) => this.demotivatorApi.GetPage(page);
        

        public Page GetMainPage() => this.demotivatorApi.GetPage(1);
        
    }
}
