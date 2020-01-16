using System;
using System.Collections.Generic;
using System.Text;

namespace WykopApi.Models
{
    [Serializable]
    public class Page
    {
        public int PageNumber { get; set; }

        public List<WykopModel> WykopModels { get; set; }
       
        public Page(int pageNumber)
        {
            this.WykopModels = new List<WykopModel>();
            this.PageNumber = pageNumber;
        }
    }
}
