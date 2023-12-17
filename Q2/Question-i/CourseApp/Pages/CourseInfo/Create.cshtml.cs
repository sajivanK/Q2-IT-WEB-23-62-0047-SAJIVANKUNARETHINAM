using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseApp.Data;
using CourseApp.Models2;

namespace CourseApp.Pages.CourseInfo
{
    public class CreateModel : PageModel
    {
        private readonly CourseApp.Data.CourseAppContext _context;

        public CreateModel(CourseApp.Data.CourseAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Courses Courses { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Courses == null || Courses == null)
            {
                return Page();
            }

            _context.Courses.Add(Courses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
