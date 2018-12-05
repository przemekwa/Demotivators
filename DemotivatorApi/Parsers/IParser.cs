using HtmlAgilityPack;
using DemotivatorApi.Models;
using System.Collections.Generic;

namespace DemotivatorApi.Parsers
{
    public interface IParser<out T>
    {
        T Parse(HtmlNode htmllNode);

        IEnumerable<T> ParseMany(HtmlNode htmllNode);
    }
}