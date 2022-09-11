using RPI.Core.Extensions;
using RPI.Hardware.RaspberryPi.Extensions;
using RPI.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRaspberryPi();
builder.Services.AddCore();
builder.Services.AddBlazor();

var app = builder.Build();

app.ConfigureBlazor();
app.Run();