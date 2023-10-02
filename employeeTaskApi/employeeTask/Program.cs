using employeeTask.Models;
using employeeTask.Services.Contract;
using employeeTask.Services.implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configire SQL
builder.Services.AddDbContext<AppDbContext>
    (a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefouitConection")));

// obj life cycle 
builder.Services.AddScoped<IEmployeeservice,Employeeservice>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Enable lazy loading
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies() // Enable lazy loading
);



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins() // or AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});









var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
