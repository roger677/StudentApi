using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
using System.Collections.Generic;

namespace StudentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
    }
}
