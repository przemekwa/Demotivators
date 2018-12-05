
using DemotivatorApi.Models;

namespace DemotivatorApi.Buldiers
{
    public abstract class Builder<T> 
    {
        public string ImgUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public abstract T Build();
    }
}
