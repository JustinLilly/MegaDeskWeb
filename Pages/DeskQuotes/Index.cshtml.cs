using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            IQueryable<DeskQuote> quoteQuery = from q in _context.DeskQuote
                                               select q;

            if (!string.IsNullOrEmpty(SearchString))
            {
                quoteQuery = quoteQuery.Where(s => s.CustomerName.Contains(SearchString));
            }


            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    quoteQuery = quoteQuery.OrderByDescending(x => x.CustomerName);
                    break;
                case "Date":
                    quoteQuery = quoteQuery.OrderBy(x => x.QuoteDate);
                    break;
                case "date_desc":
                    quoteQuery = quoteQuery.OrderByDescending(x => x.QuoteDate);
                    break;
                default:
                    quoteQuery = quoteQuery.OrderBy(x => x.CustomerName);
                    break;
            }

            DeskQuote = await quoteQuery
                .Include(d => d.Desk).Include(d => d.DeliveryType)
                .ToListAsync();
        }
    }
}
