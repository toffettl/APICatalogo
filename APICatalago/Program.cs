﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APICatalago.Data;
using System.Text.Json.Serialization;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;
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
