using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WesternInn_IL_RR_MN.Models;

namespace WesternInn_IL_RR_MN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<WesternInn_IL_RR_MN.Models.Guest> Guest { get; set; }

        public DbSet<WesternInn_IL_RR_MN.Models.Room> Room { get; set; }

        public DbSet<WesternInn_IL_RR_MN.Models.Booking> Booking { get; set; }
    }
}