using DemotivatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemotivatorApi.Buldiers
{
    public sealed class DemotivatorSlideBuilder : Builder<DemotivatorSlide>
    {
        public override DemotivatorSlide Build()
        {
            var rezult = new DemotivatorSlide
            {
                ImgUrl = this.ImgUrl,
                Description= this.Description
            };

            return rezult;
        }
    }
}
