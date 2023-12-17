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
    public class IndexModel : PageModel
    {
        private readonly CourseApp.Data.CourseAppContext _context;

        public IndexModel(CourseApp.Data.CourseAppContext context)
        {
            _context = context;
        }

        public IList<Courses> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses.ToListAsync();
            }
        }
    }
}
