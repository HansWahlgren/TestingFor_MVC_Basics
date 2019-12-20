using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class FeverCheckController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.FeverResult = CheckFever.CalculateFever(10);
            ViewBag.FeverList = CheckFever.testList;

            return View();
        }

        //public string CheckFever(float value)
        public void FeverControll(float value)
        {
            ViewBag.FeverResult = CheckFever.CalculateFever(value);

            //    string result = Models.CheckFever.CalculateFever(value);
            //   return ViewBag.FeverResult;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string info)
        {
            if (string.IsNullOrWhiteSpace(info))
            {
                ViewBag.Msg = "You must enter some text.";
                return View();
            }
            else
            {
                CheckFever.testList.Add(new CheckFever() { Info = info });
                return RedirectToAction("Index");
            }
        }
    }
}