using BMITrackerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMITrackerApp.Models.Entities;
using BMITrackerApp.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BMITrackerApp.Services
{
	public class DbHealthProfileRepository : IHealthProfileRepository
	{
		//Inject database context
		private HealthProfileDbContext _db;

		public DbHealthProfileRepository(HealthProfileDbContext db)
		{
			_db = db;
		}

		public HealthProfile Create(HealthProfile healthProfile)
		{
			//Add the health profile to the database and save changes
			_db.HealthProfile.Add(healthProfile);
			_db.SaveChanges();
			return healthProfile;
		}

		public void Delete(int id)
		{
			//Find the health profile that matches the id. Then, remove it from the database and save changes
			HealthProfile healthProfile = _db.HealthProfile.Find(id);
			_db.HealthProfile.Remove(healthProfile);
			_db.SaveChanges();
		}

		public HealthProfile Read(int id)
		{
			//Return the health profile where the id matches it
			return _db.HealthProfile.FirstOrDefault(hp => hp.Id == id);
		}

		public ICollection<HealthProfile> ReadAll()
		{
			//Return all health profiles
			return _db.HealthProfile.ToList();
		}

		public void Update(int id, HealthProfile healthProfile)
		{
			//Update the health profile and save changes
			_db.Entry(healthProfile).State = EntityState.Modified;
			_db.SaveChanges();
		}

		public ICollection<HealthProfile> GetReport(string reportType)
		{
			//Create an empty ICollection to return the matching profiles for the reports
			ICollection<HealthProfile> matchingProfiles = new List<HealthProfile>();

			//Get all profiles from the database
			ICollection<HealthProfile> profiles = _db.HealthProfile.ToList();

			//Loop through all profiles int the database, and if it is equal to the report type passed in, add all the correct profiles to the report
			foreach(var profile in profiles)
			{
				if(profile.GetBodyState() == "Overweight" && reportType == "overweight")
				{
					matchingProfiles.Add(profile);
				} else if(profile.GetBodyState() == "Underweight" && reportType == "underweight")
				{
					matchingProfiles.Add(profile);
				}
				else if (profile.GetBodyState() == "Obese" && reportType == "obese")
				{
					matchingProfiles.Add(profile);
				}
			}

			//Return the ICollection of profiles that matched the report type
			return matchingProfiles;
		}
	}
}
