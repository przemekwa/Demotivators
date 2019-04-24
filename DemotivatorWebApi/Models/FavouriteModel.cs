using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.Models
{
    public class FavouriteModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
