using System.Collections.Generic;
using DemotivatorApi.Models;

namespace DemotivatorApi.Interface
{
    public interface IDemotivatorApi
    {
        IEnumerable<Page> GetPages(int first, int last);
        Page GetPage(int page);
        Page GetMainPage();
    }
}
