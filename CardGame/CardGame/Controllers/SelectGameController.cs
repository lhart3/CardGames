using CardGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardGame.Controllers
{
    public class SelectGameController : Controller
    {
        Game Game { get; set; }
        //
        // GET: /SelectGame/

        public ActionResult GameSelect()
        {
            return View();
        }

    }
}
