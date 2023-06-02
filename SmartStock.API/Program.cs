using Microsoft.EntityFrameworkCore;
using SmartStock.Data.Repository.Interface;
using SmartStock.Data.Repository;
using SmartStock.Domain.Entities;
using SmartStock.Service.Services;
using SmartStock.Service.Services.Interface;
using SmartStock.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SmartStock.Domain.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<SmartStockContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
