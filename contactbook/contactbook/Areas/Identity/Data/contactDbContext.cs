using contactbook.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using phonebookapp.Models;

namespace contactbook.Data;

public class contactDbContext : IdentityDbContext<contactbookUser>
{
    public contactDbContext(DbContextOptions<contactDbContext> options)
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

public DbSet<phonebookapp.Models.Contact> Contact { get; set; } = default!;
}
