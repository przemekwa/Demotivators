
using DemotivatorWebApi.ControllersLogic;
using JbzdyApi;
using JbzdyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemotivatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  JbzdyController : ControllerBase
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
    }
}
