﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public DetailsModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }

        public Desk Desk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk).Include(d => d.DeliveryType).Include(d => d.Desk.DesktopMaterial).FirstOrDefaultAsync(m => m.DeskQuoteId == id);
            if (DeskQuote == null)
            {
                return NotFound();
            }
            Console.WriteLine(DeskQuote.DeliveryTypeId);
            return Page();
        }
    }
}
