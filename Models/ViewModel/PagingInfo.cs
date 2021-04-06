using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModel
{
    public class PagingInfo
    {
        // This class is used to contol paging for the Bowler database
        public int TotalNumItems { get; set; }
        
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage => (int) Math.Ceiling((decimal) TotalNumItems / ItemsPerPage);
    }
}
