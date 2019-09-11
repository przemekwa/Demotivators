using JbzdyApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public interface IJbzdyLogic
    {
        Page GetMainPage();
        Page GetPage(int page);
        Page GetPageWithLogin(string user, string password, int page);
    }
}