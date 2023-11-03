using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Models;
using Domain.Repository;
using Domain.UnitOfWork;
using Repos;
using ServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using Domain.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddCors(options =>
//{

//    options.AddDefaultPolicy(
//        policy =>
//        {
//            policy.AllowAnyOrigin();
//                //.AllowAnyHeader()
//                //.AllowAnyMethod();
//        });
//});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmployeeDetailsDbContext>
   (options => options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection")));
builder.Services.AddScoped<IGenericRepo<EmployeeDetail>, GenericRepo<EmployeeDetail>>();
//DI for employee repo
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
//DI for UOW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//DI for the service layer of employee 
builder.Services.AddScoped<IEmployeeServiceLayer, EmployeeServiceLayer>();
//builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();
//ConfigurationManager configuration = builder.Configuration;
//IWebHostEnvironment environment = builder.Environment;




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
app.UseCors( x => x
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
