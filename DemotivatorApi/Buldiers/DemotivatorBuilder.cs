using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemotivatorApi.Models;

namespace DemotivatorApi.Buldiers
{
    public sealed class DemotivatorBuilder : Builder<Demotivator>
    {
        public override Demotivator Build()
        {
            var rezult = new Demotivator
            {
                Url = this.Url,
                ImgUrl = this.ImgUrl,
            };

            return rezult;
        }
    }
}
