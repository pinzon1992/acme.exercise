using acme.exercise.Model;

namespace acme.exercise.Controller
{
    public interface IScheduleController
    {
        Dictionary<string, int> GetScheduleCoincidence();

        List<ScheduledWork> GetAllScheduledWorkFromEmployees();
    }
}
