﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectClinica.Models;
using proiectVetApp.Data;

namespace proiectVetApp.Pages.Disinfestations
{
    public class IndexModel : PageModel
    {
        private readonly proiectVetApp.Data.proiectVetAppContext _context;

        public IndexModel(proiectVetApp.Data.proiectVetAppContext context)
        {
            _context = context;
        }

        public IList<Disinfestation> Disinfestation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Disinfestation = await _context.Disinfestation
                .Include(d => d.Animal).ToListAsync();
        }
    }
}
