using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {//for keeping track of page numbers
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalNumItems { get; set; }

        public int numPages =>(int) (Math.Ceiling((decimal) totalNumItems / itemsPerPage));
    }
}
