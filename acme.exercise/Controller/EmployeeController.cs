using acme.exercise.Model;
using System.Globalization;

namespace acme.exercise.Controller
{
    public class EmployeeController : IEmployeeController
    {
        public List<Employee> GetAllEmployeesFromFile(string file_path)
        {
            List<Employee> employees = new List<Employee>();
            using (var reader = new StreamReader(file_path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('=');
                    var name = values[0];
                    var schedule = values[1].Split(',');
                    employees.Add(new Employee { Name = name, Schedule = GetEmployeeSchedule(schedule) });
                }
            }

            return employees;
        }

        public List<ScheduledWork> GetEmployeeSchedule(string[] schedule)
        {
            List<ScheduledWork> result_schedule = new List<ScheduledWork>();
            foreach (var scheduleItem in schedule)
            {
                var hours = scheduleItem.Substring(2, scheduleItem.Length - 2);
                result_schedule.Add(new ScheduledWork { Day = scheduleItem.Substring(0, 2), CheckIn = DateTime.ParseExact(hours.Split('-')[0], "HH:mm", CultureInfo.InvariantCulture), CheckOut = DateTime.ParseExact(hours.Split('-')[1], "HH:mm", CultureInfo.InvariantCulture) });
            }

            return result_schedule;
        }
    }
}
