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
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<CentalContext>();

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
