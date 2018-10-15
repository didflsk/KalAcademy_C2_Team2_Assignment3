using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Pic")]
    public class PicController : Controller
    {
        ///private readonly IHostingEnviroment _ env;
        ///public PicController(IHostingEnvironment env)
        /// {
        ///   _env = env;
        /// }
        /// [Route("{id}"]
        /// public IActionResult GetImage(int id)
        /// {
        /// var webRoot = env.WebRootPath;
        /// var path = Path.Combine(webRoot+ "/pics/", "event-" + id + ".png or .jpg");
        /// var buffer = System.IO.File.ReadAllBytes(path);
        /// return File(buffer, "image/png or image/jpg");

    }
}