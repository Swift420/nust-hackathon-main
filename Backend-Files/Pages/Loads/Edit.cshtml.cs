using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using schoolAdmin.Data;
using schoolAdmin.Models;

namespace schoolAdmin.Pages.Loads
{
    public class EditModel : PageModel
    {
        private readonly schoolAdmin.Data.schoolAdminContext _context;

        public EditModel(schoolAdmin.Data.schoolAdminContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Workloads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkloadsExists(Workloads.WorkloadID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkloadsExists(int id)
        {
            return _context.Workloads.Any(e => e.WorkloadID == id);
        }
    }
}
