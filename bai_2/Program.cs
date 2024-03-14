
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace bai_2
{
    public class program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Starup>()
                .Build();
    }
}