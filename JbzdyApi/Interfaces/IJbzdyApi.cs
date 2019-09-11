using JbzdyApi.Models;

namespace JbzdyApi
{
    public interface IJbzdyApi
    {
        Page GetMainPage();
        Page GetPage(int page);
        Page GetPageWithLogin(string user, string password,int page);
    }
}