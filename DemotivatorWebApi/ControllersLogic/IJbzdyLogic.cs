using JbzdyApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public interface IJbzdyLogic
    {
        Page GetMainPage();
        Page GetPage(int page);
    }
}