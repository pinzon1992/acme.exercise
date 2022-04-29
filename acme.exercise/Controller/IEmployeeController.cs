using acme.exercise.Model;

namespace acme.exercise.Controller
{
    public interface IEmployeeController
    {
        List<ScheduledWork> GetEmployeeSchedule(string[] schedule);

        List<Employee> GetAllEmployeesFromFile(string file_path);
    }
}
