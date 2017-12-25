using BMITrackerApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMITrackerApp.Services.Interfaces
{
	//Implement a basic CRUD interface with an extra method that gets the specified report
    public interface IHealthProfileRepository
    {
		HealthProfile Create(HealthProfile healthProfile);

		HealthProfile Read(int id);

		ICollection<HealthProfile> ReadAll();

		void Update(int id, HealthProfile healthProfile);

		void Delete(int id);

		ICollection<HealthProfile> GetReport(string reportType);
	}
}