using BowlingLeague.Models;
using BowlingLeague.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        // Set up BowlingLeague context / page size
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index(string team, int page = 1)
        {
            // Add teams to viewbag so we can iterate through them for the selector / use for where queries
            IEnumerable<Team> teams = _context.Teams.OrderBy(t => t.TeamId);
                       
            ViewBag.Teams = teams;
            
            return View(
                // Create a bowler list view model to control pagination
                new BowlerListViewModel
                {
                    bowlers = _context.Bowlers.Where(b => team == null || teams.First(f => f.TeamName == team).TeamId == b.TeamId)
                            .OrderBy(b => b.BowlerId)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = team == null ? _context.Bowlers.Count() : _context.Bowlers.Where(b => team == null || teams.First(f => f.TeamName == team).TeamId == b.TeamId).Count()
                    },

                    CurrentTeam = team
                }
            );
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
