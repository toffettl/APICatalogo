using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APICatalago.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APICatalagoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APICatalagoContext") ?? throw new InvalidOperationException("Connection string 'APICatalagoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
