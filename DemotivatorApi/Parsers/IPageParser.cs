using DemotivatorApi.Models;

namespace DemotivatorApi.Parsers
{
    public interface IPageParser
    {
        Page Parse(int pageNumber);
    }
}