using RPI.Core.Extensions;
using RPI.Hardware.RaspberryPi.Extensions;
using RPI.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5120");

builder.Services.AddRaspberryPi();
builder.Services.AddCore();
builder.Services.AddBlazor();

var app = builder.Build();

app.ConfigureCore();
app.ConfigureBlazor();
app.Run();