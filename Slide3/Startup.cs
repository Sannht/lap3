using Microsoft.AspNetCore.Builder;

namespace Slide3
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
        }
           
    }
}
