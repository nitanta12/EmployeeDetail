using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Models;
using Repos;
using Domain.Repository;
using Domain.UnitOfWork;
using ServiceLayer;
using AutoMapper;
using APIs.DTOs;
using APIs.Factory;
using Domain.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Add services to the container.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Way-1: Register Profiles and/or Mapping manually.

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDetailsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection")));
//DI for Generic Repository
builder.Services.AddScoped<IGenericRepo<EmployeeDetail>, GenericRepo<EmployeeDetail>>();
//DI for employee repo
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
//DI for UOW
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
//DI for the service layer of employee 
builder.Services.AddScoped<IEmployeeServiceLayer, EmployeeServiceLayer>();
builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<
    EmployeeDto, EmployeeDetail>().ReverseMap();
   // cfg.CreateMap<
   //EmployeeDetail,EmployeeDto>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
