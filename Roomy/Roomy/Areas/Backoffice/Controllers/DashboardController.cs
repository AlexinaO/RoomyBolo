using Roomy.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Areas.Backoffice.Controllers
{
    [AuthenticationFilter]
    //[Authorize()]
    public class DashboardController : Controller
    {
        
        // GET: Backoffice/Dashboard
        public ActionResult Index()
        {

            return View();
        }
    }
}