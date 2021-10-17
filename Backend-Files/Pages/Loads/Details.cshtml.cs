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
    public class DetailsModel : PageModel
    {
        private readonly schoolAdmin.Data.schoolAdminContext _context;

        public DetailsModel(schoolAdmin.Data.schoolAdminContext context)
        {
            _context = context;
        }

        public Workloads Workloads { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workloads = await _context.Workloads.FirstOrDefaultAsync(m => m.WorkloadID == id);

            if (Workloads == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
