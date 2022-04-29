using acme.exercise.Controller;

if (args.Length == 0)
{
    Console.WriteLine("Path of file wasn't supplied, finishing app");
    Environment.Exit(0);
}

string file = args[0];

ScheduleController s_controller = new ScheduleController(new EmployeeController(), file);
var coincidences = s_controller.GetScheduleCoincidence();

foreach (var item in coincidences)
{
    Console.WriteLine(item.Key + " " + coincidences[item.Key]);
}

