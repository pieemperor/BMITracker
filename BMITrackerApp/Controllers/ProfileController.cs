using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMITrackerApp.Services.Interfaces;
using BMITrackerApp.Models.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMITrackerApp.Controllers
{
	public class ProfileController : Controller
	{
		//Inject health profile repository
		private IHealthProfileRepository _healthProfiles;

		public ProfileController(IHealthProfileRepository healthProfiles)
		{
			_healthProfiles = healthProfiles;
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(HealthProfile healthProfile)
		{
			//If the model state is valid, update the profile
			if (ModelState.IsValid)
			{
				_healthProfiles.Create(healthProfile);
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		public IActionResult Edit(int id)
		{
			//Read profile from database, and if it's found, show the edit page - otherwise redirect to index
			var healthProfile = _healthProfiles.Read(id);
			if (healthProfile == null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View(healthProfile);
		}

		[HttpPost]
		public IActionResult Edit(HealthProfile healthProfile)
		{
			//If the model state is valid, update the profile
			if (ModelState.IsValid)
			{
				_healthProfiles.Update(healthProfile.Id, healthProfile);
				return RedirectToAction("Index", "Home");
			}
			return View(healthProfile);
		}

		public IActionResult Details(int id)
		{
			//Read profile from database, and if it's found, show the details page - otherwise redirect to index
			var healthProfile = _healthProfiles.Read(id);
			if (healthProfile == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(healthProfile);
		}

		public IActionResult Delete(int id)
		{
			//Read profile from database, and if it's found, show the confirm delete page - otherwise redirect to index
			var healthProfile = _healthProfiles.Read(id);
			if (healthProfile == null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View(healthProfile);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			//Delete profile
			_healthProfiles.Delete(id);
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Report([Bind(Prefix = "id")]string reportType)
		{

			//If the reportType is valid, display the report with the correct reportType
			if(reportType == "underweight" || reportType == "overweight" || reportType == "obese" )
			{
				return View(_healthProfiles.GetReport(reportType));
			}
			return RedirectToAction("Reports");
		}

		public IActionResult Reports()
		{
			return View();
		}
	}
}