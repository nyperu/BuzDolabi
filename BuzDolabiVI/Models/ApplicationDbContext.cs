using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuzDolabiVI.Models
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Tarif> Tarif { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}