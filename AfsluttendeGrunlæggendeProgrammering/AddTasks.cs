public class TaskItem
{
    public string TaskName { get; set; }
    public bool Complete { get; set; }
    public DayOfWeek Weekday { get; set; }
    public TaskItem(string taskName, DayOfWeek weekday)
    {
        TaskName = taskName;
        Complete = false;
        Weekday = weekday;
    }
}