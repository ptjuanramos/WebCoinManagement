using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCoinManagement.Controllers
{
    [Authorize]
    public class TradeRoomController : Controller
    {
        // GET: TradeRoom
        public ActionResult Index()
        {
            return View();
        }
    }
}