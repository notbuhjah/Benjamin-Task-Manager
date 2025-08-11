public class TaskItem
{
    public string TaskName { get; set; }
    public bool Complete { get; set; }
    public TaskItem(string taskName)
    {
        TaskName = taskName;
        Complete = false;
    }
}