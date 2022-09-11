using Microsoft.Extensions.FileProviders;

namespace RPI.Web.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureBlazor(this WebApplication app)
    {
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(
                WebContentHelper.GetPathToWebContent()),
              
            RequestPath = new PathString("")
        });
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
    }
}