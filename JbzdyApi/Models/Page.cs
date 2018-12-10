using System;
using System.Collections.Generic;
using System.Text;

namespace JbzdyApi.Models
{
    [Serializable]
    public class Page
    {
        public int PageNumber { get; set; }

        public List<JbzdyModel> JbzdyModels { get; set; }
       
        public Page(int pageNumber)
        {
            this.JbzdyModels = new List<JbzdyModel>();
            this.PageNumber = pageNumber;
        }
    }
}
