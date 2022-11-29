using System;
using System.Globalization;

namespace ExercicioEnum
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter department's name: ");
			string departmentName = Console.ReadLine();

			Console.WriteLine("Enter worker data:");
			Console.Write("Name: ");
			string workerName = Console.ReadLine();
			Console.Write("Level (Junior/MidLevel/Senior): ");
			WorkerLevel workerLevel = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
			Console.Write("Base salary: ");
			double baseSalary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

			Department department = new Department(departmentName);
			Worker worker = new Worker(workerName, workerLevel, baseSalary, department);

			Console.WriteLine();
			Console.Write("How many contracts did this worker?");
			int qttyContracts = Convert.ToInt16(Console.ReadLine());

			for (int contract = 1; contract <= qttyContracts; contract++)
			{
				Console.WriteLine();
				Console.WriteLine($"Enter #{contract} contract data: ");
				Console.Write("Date (DD/MM/YYYY): ");
				DateTime date = DateTime.Parse(Console.ReadLine());
				Console.Write("Value per hour: ");
				double valuePerHour = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
				Console.Write("Duration (hours): ");
				int durationHours = Convert.ToInt16(Console.ReadLine());

				HourContract newContract = new HourContract(date, valuePerHour, durationHours);

				worker.AddContract(newContract);
			}

			Console.WriteLine();
			Console.Write("Enter month and year to calculate the income: ");
			string monthAndYear = Console.ReadLine();

			int month = Convert.ToInt32(monthAndYear.Substring(0, 2));
			int year = Convert.ToInt32(monthAndYear.Substring(3, 4));

			Console.WriteLine();
			Console.WriteLine($"Name: {worker.Name}");
			Console.WriteLine($"Department: {worker.Department.Name}");
			Console.WriteLine($"Income for {monthAndYear}: {worker.Income(month, year)}");
		}
	}
}
