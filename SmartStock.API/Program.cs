using Microsoft.EntityFrameworkCore;
using SmartStock.Data.Repository.Interface;
using SmartStock.Data.Repository;
using SmartStock.Domain.Entities;
using SmartStock.Service.Services;
using SmartStock.Service.Services.Interface;
using SmartStock.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<SmartStockContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

