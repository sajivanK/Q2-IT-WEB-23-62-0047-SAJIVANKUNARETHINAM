using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourseApp.Models1;
using CourseApp.Models2;

namespace CourseApp.Data
{
    public class CourseAppContext : DbContext
    {
        public CourseAppContext (DbContextOptions<CourseAppContext> options)
            : base(options)
        {
        }

        public DbSet<CourseApp.Models1.Students> Students { get; set; } = default!;

        public DbSet<CourseApp.Models2.Courses>? Courses { get; set; }
    }
}
