using acme.exercise.Model;
using acme.exercise.Utils;
using System.Globalization;

namespace acme.exercise.Controller
{
    public class ScheduleController : IScheduleController
    {
        public readonly IEmployeeController _employeeController;
        public readonly string _filePath;
        public ScheduleController(IEmployeeController employeeController, string file_path)
        {
            _employeeController = employeeController;
            _filePath = file_path;
        }

        public List<ScheduledWork> GetAllScheduledWorkFromEmployees()
        {
            List<Employee> employees = _employeeController.GetAllEmployeesFromFile(_filePath);
            List<ScheduledWork> result = new List<ScheduledWork>();
            foreach (Employee employee in employees)
            {
                foreach (var schedule in employee.Schedule)
                {
                    if(result.FirstOrDefault(x=> x.Day == schedule.Day && x.CheckIn == schedule.CheckIn && x.CheckOut == schedule.CheckOut) is null) {
                        result.Add(new ScheduledWork { Day = schedule.Day, CheckIn = schedule.CheckIn, CheckOut = schedule.CheckOut });
                    }
                }
            }

            return result;
        }

        public Dictionary<string, int> GetScheduleCoincidence()
        {
            List<Employee> employees = _employeeController.GetAllEmployeesFromFile(_filePath).OrderBy(x=>x.Schedule.Count()).ToList();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var employee in employees)
            {
                List<ScheduledWork> scheduledWorks = employee.Schedule;
                List<Employee> employeeCoincidences = new List<Employee>();
                foreach (var schedule in scheduledWorks)
                {
                    employeeCoincidences = employees.Where(x => x.Name != employee.Name && x.Schedule.Any(y => y.Day == schedule.Day && (y.CheckIn >= schedule.CheckIn && y.CheckOut<=schedule.CheckOut))).ToList();
                    result = Helper.GetCoincidencesDict(employee, employeeCoincidences, result);
                }
            }

            result = Helper.RemoveReverseKeysOnDict(result);
            return result;
        }

    }
}
