﻿using OnlineStore.Application;
using OnlineStore.Extensions;
using OnlineStore.Infrastructure;
using OnlineStore.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
dataContext?.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.Run();

