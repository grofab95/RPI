using RPI.Core.Extensions;
using RPI.Core.Logging;
using RPI.Hardware.RaspberryPi.Extensions;
using RPI.Web.Extensions;
using Serilog;

LoggingHelper.AddLoggerConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5120");
builder.Host.UseSerilog();

builder.Services.AddRaspberryPi();
builder.Services.AddCore();
builder.Services.AddBlazor();

var app = builder.Build();

app.ConfigureCore();
app.ConfigureBlazor();
app.Run();