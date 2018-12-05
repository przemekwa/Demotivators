using DemotivatorApi.Models;
using DemotivatorWebApi.ControllersLogic;
using Microsoft.AspNetCore.Mvc;

namespace DemotivatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemotivatorsController : ControllerBase
    {
        private readonly IDemotivatorsLogic demotivatorsLogic;

        public DemotivatorsController(IDemotivatorsLogic demotivatorsLogic)
        {
            this.demotivatorsLogic = demotivatorsLogic;
        }

        [HttpGet]
        public ActionResult<Page> Get()
        {
            return this.demotivatorsLogic.GetMainPage();
        }

        
        [HttpGet("{pageId:int}")]
        public ActionResult<Page> Get(int pageId)
        {
            return this.demotivatorsLogic.GetPage(pageId);
        }

       
    }
}
