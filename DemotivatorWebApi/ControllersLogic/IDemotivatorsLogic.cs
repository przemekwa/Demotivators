using DemotivatorApi.Models;

namespace DemotivatorWebApi.ControllersLogic
{
    public interface IDemotivatorsLogic
    {
        Page GetMainPage();
        Page GetPage(int page);
    }
}