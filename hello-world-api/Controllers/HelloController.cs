using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace hello_world_api.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        // GET api/hello?name=David
        [HttpGet]
        public string Get([FromQuery] string name = "World")
        {
            var message = $"Hello world {name}";

            var dir = Directory.GetCurrentDirectory();
            while (dir != null && Directory.GetFiles(dir, "*.sln").Length == 0)
                dir = Directory.GetParent(dir)?.FullName;

            var outputPath = Path.Combine(dir ?? Directory.GetCurrentDirectory(), "helloworld.txt");
            System.IO.File.WriteAllText(outputPath, message);

            return message;
        }
    }
}
