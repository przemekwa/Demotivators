using System;
using System.Collections.Generic;
using System.Text;

namespace WykopApi.Models
{
    public class WykopModel
    {
        public string ImgUrl { get; set; }
        public string Url { get; set; }
        public string Title { get; internal set; }
    }
}
