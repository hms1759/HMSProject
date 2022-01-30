

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelMgt.Models.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Visitors> DbVisitor { get; set; }
    }
}
