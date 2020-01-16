using DemotivatorWebApi.ControllersLogic;
using Microsoft.AspNetCore.Mvc;
using WykopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemotivatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WykopController : ControllerBase
    {
        private readonly IWykopLogic wykopLogic;

        public WykopController(IWykopLogic wykopLogic)
        {
            this.wykopLogic = wykopLogic;
        }

        [HttpGet("{tags?}")]
        public ActionResult<Page> Get(string tags)
        {
            return this.wykopLogic.GetMainPage(tags);
        }

        [HttpGet("{pageId:int}")]
        public ActionResult<Page> Get(int pageId)
        {
            return this.wykopLogic.GetPage(pageId);
        }

    }
}
