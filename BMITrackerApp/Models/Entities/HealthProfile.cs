using System;
using System.Collections.Generic;

namespace BMITrackerApp.Models.Entities
{
    public partial class HealthProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

		public int GetAge()
		{
			//Calculate age and return it
			int age = 2017 - YearOfBirth;
			return age;
		}

		public int CalculateMaxHeartRate()
		{
			//Calculate max heart rate by subtrating their age from 220 and return it
			int maxHeartRate = 220 - GetAge();
			return maxHeartRate;
		}

		public int CalculateMinimumTargetHeartRate()
		{
			//Calculate their minimum target heart rate by dividing their max heart rate by 2 and returning it
			double minimumTargetRate = CalculateMaxHeartRate() / 2.0;
			return (int)minimumTargetRate;
		}

		public int CalculateMaximumTargetHeartRate()
		{
			//Calculate their maximum target heart rate by multiplying their max heart rate by .85 and returning it
			double maximumTargetRate = CalculateMaxHeartRate() * .85;
			return (int)maximumTargetRate;
		}

		public double CalculateBMI()
		{
			//Calculate their BMI by using the BMI formula
			double BMI = (Weight * 703.0) / (Height * Height);
			return BMI;
		}

		public string GetBodyState()
		{
			//Determine what their body state is by checking their BMI and return bodyState
			double BMI = CalculateBMI();
			string bodyState = "Invalid";
			if(BMI < 18.5)
			{
				bodyState = "Underweight";
			} else if(BMI >= 18.5 && BMI <= 24.9)
			{
				bodyState = "Normal";
			} else if(BMI >= 25 && BMI <= 29.9)
			{
				bodyState = "Overweight";
			} else if(BMI >= 30)
			{
				bodyState = "Obese";
			}
			return bodyState;
		}
	}
}
