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
    public class DeleteModel : PageModel
    {
        private readonly schoolAdmin.Data.schoolAdminContext _context;

        public DeleteModel(schoolAdmin.Data.schoolAdminContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workloads = await _context.Workloads.FindAsync(id);

            if (Workloads != null)
            {
                _context.Workloads.Remove(Workloads);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
