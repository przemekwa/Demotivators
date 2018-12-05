using System;
using System.Collections.Generic;

namespace DemotivatorApi.Models
{
    [Serializable]
    public class Page
    {
        public int PageNumber { get; set; }

        public List<Demotivator> DemotivatorCollection { get; set; }
        
        public List<DemotivatorSlide> DemotivatorSlideCollection { get; set; }

        public Page(int pageNumber)
        {
            this.DemotivatorCollection = new List<Demotivator>();
            this.DemotivatorSlideCollection = new List<DemotivatorSlide>();

            this.PageNumber = pageNumber;
        }
    }
}
