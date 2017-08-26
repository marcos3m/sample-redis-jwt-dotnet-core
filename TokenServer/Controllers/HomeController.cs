using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenServer.Controllers
{
    /// <summary>
    /// HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// HomeController.
        /// </summary>
        public HomeController()
        {
        }

        /// <summary>
        /// Redirect to swagger ui.
        /// </summary>
        /// <response code="200"></response>
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/swagger/ui/index.html");
        }
    }
}
