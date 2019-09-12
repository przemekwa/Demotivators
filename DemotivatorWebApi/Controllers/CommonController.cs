using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController
    {
        [HttpGet("version")]
        public ActionResult<string> GetVersion()
        {
            return "1.1.3";
        }
    }
}
