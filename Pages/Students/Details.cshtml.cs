using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Models;

namespace Razor.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Razor.Data.SchoolContext _context;

        public DetailsModel(Razor.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                            .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Course)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (student is not null)
            {
                Student = student;

                return Page();
            }

            return NotFound();
        }
    }
}
