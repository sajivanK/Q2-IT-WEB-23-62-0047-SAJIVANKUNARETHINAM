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
    public class DeleteModel : PageModel
    {
        private readonly CourseApp.Data.CourseAppContext _context;

        public DeleteModel(CourseApp.Data.CourseAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var students = await _context.Students.FindAsync(id);

            if (students != null)
            {
                Students = students;
                _context.Students.Remove(Students);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
