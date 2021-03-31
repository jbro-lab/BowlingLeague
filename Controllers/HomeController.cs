using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        //create
        private BowlingLeagueContext _context { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            _context = con;
            _logger = logger;
        }

        public IActionResult Index(long? teamid, string teamName,  int pageNum = 0)
        {
            //sets page size to 5
            int pageSize = 5;
            
            //passes in IndexViewModel
            return View(new IndexViewModel
            {
                Bowlers = _context.Bowlers
                    .Where(b => b.TeamId == teamid || teamid == null)
                    .OrderBy(t => t.BowlerLastName)
                    .Skip(pageNum != 0 ? (pageNum - 1) * pageSize : 0)
                    .Take(pageSize),
                PageNumberingInfo = new PageNumberingInfo
                {
                    itemsPerPage = pageSize,
                    totalNumItems = (teamid == null ? _context.Bowlers.Count() :
                    _context.Bowlers.Where(b => b.TeamId == teamid).Count()),
                    currentPage = (teamid != null ? 1 : pageNum)
                },
                TeamName = teamName
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
