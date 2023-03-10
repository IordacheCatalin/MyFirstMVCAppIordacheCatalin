using MyFirstMVCAppIordacheCatalin.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFirstMVCAppIordacheCatalin.Repositories;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProgrammingClubDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<ProgrammingClubDataContext, ProgrammingClubDataContext>();
builder.Services.AddTransient<AnnouncementsRepository, AnnouncementsRepository>();
builder.Services.AddTransient<CodeSnippetsRepository, CodeSnippetsRepository>();
builder.Services.AddTransient<MembershipsRepository, MembershipsRepository>();
builder.Services.AddTransient<MembersRepository, MembersRepository>();
builder.Services.AddTransient<MembershipTypesRepository, MembershipTypesRepository>();

builder.Services
    .AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];

});


var app = builder.Build();

app.UseAuthentication();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
