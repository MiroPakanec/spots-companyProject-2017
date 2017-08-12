﻿using System.Web.Mvc;

namespace spots.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}