using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace bai_2
{
    public class Starup
    {
        private IConfiguration _config;
        public Starup(IConfiguration config)
        {
            _config = config;
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 1 </div>");
                await next.Invoke();
                await context.Response.WriteAsync("<div> Returning from the middleware 1 </div>");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 2 </div>");
                await next.Invoke();
                await context.Response.WriteAsync("<div> Returning from the middleware 2 </div>");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 3 </div>");
            });
        }
    }
}