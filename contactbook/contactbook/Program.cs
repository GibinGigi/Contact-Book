using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using contactbook.Data;
using contactbook.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("contactDbContextConnection") ?? throw new InvalidOperationException("Connection string 'contactDbContextConnection' not found.");

builder.Services.AddDbContext<contactDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<contactbookUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<contactDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
