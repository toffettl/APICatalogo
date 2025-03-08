using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APICatalago.Data;
using System.Text.Json.Serialization;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APICatalogoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APICatalagoContext") ?? throw new InvalidOperationException("Connection string 'APICatalagoContext' not found.")));

builder.Services.AddTransient<IMeuServico, MeuServico>();
// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
