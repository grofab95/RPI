using RPI.Core.Extensions;
using RPI.Hardware.RaspberryPi.Extensions;
using RPI.Web;
using RPI.Web.Extensions;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WebContentHelper.GetPathToWebContent()
});

builder.Services.AddRaspberryPi();
builder.Services.AddCore();
builder.Services.AddBlazor();

var app = builder.Build();

app.ConfigureBlazor();
app.Run();