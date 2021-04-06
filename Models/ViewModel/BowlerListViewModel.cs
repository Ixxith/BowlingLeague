using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModel
{
    // This class is used to create a view model for the Bowler class / table
    public class BowlerListViewModel
    {
        public IEnumerable<Bowler> bowlers { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentTeam { get; set; }
    }
}
