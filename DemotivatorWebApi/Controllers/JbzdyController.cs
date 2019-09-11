
using DemotivatorWebApi.ControllersLogic;
using JbzdyApi;
using JbzdyApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DemotivatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JbzdyController : ControllerBase
    {
        private readonly IJbzdyLogic jbzdyLogic;

        public JbzdyController(IJbzdyLogic jbzdyLogic)
        {
            this.jbzdyLogic = jbzdyLogic;
        }

        [HttpGet]
        public ActionResult<Page> Get()
        {
            return this.jbzdyLogic.GetMainPage();
        }

        [HttpGet("{pageId:int}")]
        public ActionResult<Page> Get(int pageId)
        {
            return this.jbzdyLogic.GetPage(pageId);
        }

        [HttpGet("login/{pageId:int}")]
        public ActionResult<Page> Test(int pageId)
        {
            return this.jbzdyLogic.GetPageWithLogin("witam2", "qwerty", pageId);
        }
    }
}
