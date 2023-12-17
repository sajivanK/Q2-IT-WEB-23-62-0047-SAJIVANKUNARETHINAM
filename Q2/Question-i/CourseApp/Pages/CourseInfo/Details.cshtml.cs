using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseApp.Data;
using CourseApp.Models2;

namespace CourseApp.Pages.CourseInfo
{
    public class DetailsModel : PageModel
    {
        private readonly CourseApp.Data.CourseAppContext _context;

        public DetailsModel(CourseApp.Data.CourseAppContext context)
        {
            _context = context;
        }

      public Courses Courses { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            if (courses == null)
            {
                return NotFound();
            }
            else 
            {
                Courses = courses;
            }
            return Page();
        }
    }
}
