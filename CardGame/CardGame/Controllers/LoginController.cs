﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardGame.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login(string username, string password)
        {
            //return View("Index", (object) "Not valid");
            return RedirectToAction("GameSelect", "SelectGame");
        }
    }
}
