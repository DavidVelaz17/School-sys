using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Models;

namespace Razor.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly Razor.Data.SchoolContext _context;

        public DetailsModel(Razor.Data.SchoolContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.ID == id);

            if (instructor is not null)
            {
                Instructor = instructor;

                return Page();
            }

            return NotFound();
        }
    }
}