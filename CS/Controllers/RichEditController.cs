using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RichEditServerBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RichEditController : ControllerBase
    {
        [HttpPost]
        [Route("SaveDocument")]
        public IActionResult SaveDocument([FromForm] string base64, [FromForm] string fileName, [FromForm] int format, [FromForm] string reason)
        {
            byte[] fileContents = System.Convert.FromBase64String(base64);
            return Ok();
        }
    }
}
