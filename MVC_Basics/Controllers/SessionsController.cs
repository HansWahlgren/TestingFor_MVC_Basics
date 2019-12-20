using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Controllers
{
    public class SessionsController : Controller
    {
        //   [Route("LookAt")]
        public IActionResult LookAt()
        {
            ViewBag.Msg = HttpContext.Session.GetString("KeyName");
            return View();
        }

        //    [Route("GuessingGame")]
        public IActionResult SaveSession(string message)
        {
            HttpContext.Session.SetString("KeyName" , message);
            return RedirectToAction("LookAt");
        }
    }
}