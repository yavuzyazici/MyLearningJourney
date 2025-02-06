using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.BusinessLayer.Extensions;
using Cental.BusinessLayer.Validators;
using Cental.BusinessLayer.Validators.BrandValidator;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//When you see AboutService. Take a property example from AboutManager and do the processes with it.
builder.Services.AddDbContext<CentalContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Registrations of Services
builder.Services.AddServiceRegistrations();

//Adding FluentValidation and Authorization
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<CreateBrandValidator>();

//Adding Identity
builder.Services.AddIdentity<AppUser, AppRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<CentalContext>()
    .AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddAuthentication();

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Login/Index";
    x.LogoutPath = "/Login/Logout";
    x.AccessDeniedPath = "/ErrorPage/AccessDenied";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.Run();
