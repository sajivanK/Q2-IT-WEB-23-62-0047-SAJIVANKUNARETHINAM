using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseApp.Data;
using CourseApp.Models1;

namespace CourseApp.Pages.StudentInfo
{
    public class DetailsModel : PageModel
    {
        private readonly CourseApp.Data.CourseAppContext _context;

        public DetailsModel(CourseApp.Data.CourseAppContext context)
        {
            _context = context;
        }

      public Students Students { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }
            else 
            {
                Students = students;
            }
            return Page();
        }
    }
}
