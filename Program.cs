using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proiectVetApp.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Animals");
    options.Conventions.AuthorizeFolder("/Disinfestations");
    options.Conventions.AuthorizeFolder("/Vaccines");
    options.Conventions.AuthorizeFolder("/VeterinaryClinics");
    options.Conventions.AuthorizeFolder("/VeterinaryVisits");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});
builder.Services.AddDbContext<proiectVetAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiectVetAppContext") ?? throw new InvalidOperationException("Connection string 'proiectVetAppContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("proiectVetAppContext") ?? throw new InvalidOperationException("Connection string 'proiectVetAppContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
