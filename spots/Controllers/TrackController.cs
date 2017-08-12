using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spots.BL.Facades.Interfaces;
using spots.Models.Log;

namespace spots.Controllers
{
    public class TrackController : Controller
    {
        private readonly ILogFacade _facade;

        public TrackController(ILogFacade facade)
        {
            _facade = facade;
        }

        //POST: /Track/Log
        [HttpPost]
        public void Log(Log model)
        {
            model.Email = User.Identity.Name;
            _facade.StoreActivity(model);
        }
    }
}