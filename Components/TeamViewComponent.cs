using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext con)
        {
            context = con;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];
            //for the filter dropdown menu
            return View(context.Teams
                .Select(t => t)
                .Distinct()
                .OrderBy(t => t.TeamName)
                .ToList());
        }
        
    }
}
