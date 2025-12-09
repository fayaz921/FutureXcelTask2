using FutureXcelTask2.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureXcelTask2.Data
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
