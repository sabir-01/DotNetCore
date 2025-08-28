using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options) //parent class ky constructor ko
        {
        }
        //    <Student> (ya mdel class ka naam hai jo table create karega)    
        public DbSet<Student> Students { get; set; } //(Students) database mein table ka naam hai


    }
}
