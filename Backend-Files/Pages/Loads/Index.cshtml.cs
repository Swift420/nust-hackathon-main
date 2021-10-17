using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using schoolAdmin.Data;
using schoolAdmin.Models;

namespace schoolAdmin.Pages.Loads
{
    public class IndexModel : PageModel
    {
        private readonly schoolAdmin.Data.schoolAdminContext _context;

        public IndexModel(schoolAdmin.Data.schoolAdminContext context)
        {
            _context = context;
        }

        public IList<Workloads> Workloads { get;set; }

        public async Task OnGetAsync()
        {
            Workloads = await _context.Workloads.ToListAsync();
        }
    }
}
