using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
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

        [ClaimsAuthorize("Produto", "Criar")]
        [HttpGet("teste1")]
        public IActionResult Get2() => Ok();

        [ClaimsAuthorize("Produto", "Editar")]
        [HttpGet("teste2")]
        public IActionResult Get3() => Ok();
    }
}
