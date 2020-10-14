using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("teste")]
        public IActionResult Get() => Ok();
    }
}
