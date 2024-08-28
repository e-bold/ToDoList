using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using one2Do;
using one2Do.Data; // included needed using statement
using one2Do.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWForecastRepository, WForecastRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Added code as it was throwing an error
builder.Services.AddRazorPages();

var connectionString = "server=localhost;user=one2do;password=gitglobal;database=one2do";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 37));

builder.Services.AddDbContext<one2doDbContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connectionString, serverVersion)
);

//Following code was edited. Commented the original builder
// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<one2doDbContext>();
builder
    .Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<one2doDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

// Call the DbInitializer to seed the database with quotes

//two roles initialization
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Basic", "Premium", "Admin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

app.Run();
