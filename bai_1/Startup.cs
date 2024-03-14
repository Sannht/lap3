using Newtonsoft.Json.Linq;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace bai_1
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("<h1>DEMO JSON</h1>");

                var bookDataString = _config["book"];

                // Đọc file JSON
                using (var reader = new StreamReader("appsettings.Development.json"))
                {
                    var jObject = JObject.Parse(reader.ReadToEnd());

                    // Lấy mảng "book"
                    var books = jObject["book"] as JArray;
                    foreach (var book in books)
                    {
                        if (book["id"].ToString() == "555")
                        {
                            // Hiển thị thông tin của sách có ID là 555
                            await context.Response.WriteAsync($"<b>Book ID:</b> {book["id"]}<br>");
                            await context.Response.WriteAsync($"<b>Language:</b> {book["language"]}<br>");
                            await context.Response.WriteAsync($"<b>Edition:</b> {book["edition"]}<br>");
                            await context.Response.WriteAsync($"<b>Author:</b> {book["author"]}<br>");
                            await context.Response.WriteAsync("<br>");

                            // Đã tìm thấy sách, nên thoát vòng lặp
                            break;
                        }
                    }
                }
            });
        }
    }
}