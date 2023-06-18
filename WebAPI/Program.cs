using DemoLibrary;
using DemoLibrary.DataAccess;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDemoDataAccess, DemoDataAccess>();

// if MediatR  version is 9   
//builder.Services.AddMediatR(typeof(DemoMediatREntryPoint).Assembly);

// if MediatR  version is 12 or above   
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DemoMediatREntryPoint).GetTypeInfo().Assembly));



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
