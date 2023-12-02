using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Data
{
    // ApplicationDbContext class extends IdentityDbContext for user and role management
    public class ApplicationDbContext : IdentityDbContext
    {
        // Constructor for ApplicationDbContext, taking DbContextOptions as parameters
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet representing the Contact model in the database
        public DbSet<ContactManager.Models.Contact> Contact { get; set; } = default!;
    }
}
