using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options) //parent class ky constructor ko
        {
        }
        public DbSet<Student> Students { get; set; } // database mein table jo create hoga Students



    }
}
