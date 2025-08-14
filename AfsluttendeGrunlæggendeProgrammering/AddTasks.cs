public class TaskItem
{
    // Name or description of the task
    public string TaskName { get; set; }

    // Indicates whether the task is completed (true) or not (false)
    public bool Complete { get; set; }

    // Day of the week when the task should be done
    public DayOfWeek Weekday { get; set; }

    // Constructor: sets task name, assigns the given weekday, and defaults 'Complete' to false
    public TaskItem(string taskName, DayOfWeek weekday)
    {
        TaskName = taskName;   // Store the provided task name
        Complete = false;      // New tasks start as not completed
        Weekday = weekday;     // Store the provided target weekday
    }
}