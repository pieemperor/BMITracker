using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMITrackerApp.Services.Interfaces;

namespace BMITrackerApp.Controllers
{
    public class HomeController : Controller
    {
		//Inject health profile repository
		private IHealthProfileRepository _healthProfiles;

		public HomeController(IHealthProfileRepository healthProfiles)
		{
			_healthProfiles = healthProfiles;
		}

		//Show all health profiles
        public IActionResult Index()
        {
            return View(_healthProfiles.ReadAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
