using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvc00.Areas.Administrator.Controllers
{


    [Area("Administrator")]
    [Route("Administrator")]
    public partial class Home1Controller : Controller
    {
        // GET: Administrator/Home
        public virtual ActionResult Index1()
        {
            return View();
        }
    }
}