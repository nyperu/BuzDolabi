using BuzDolabiVI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuzDolabiVI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BuzDolabiVI.Models.Yorum> Yorum { get; set; }
        public DbSet<BuzDolabiVI.Models.Tarif> Tarif { get; set; }
    }
}