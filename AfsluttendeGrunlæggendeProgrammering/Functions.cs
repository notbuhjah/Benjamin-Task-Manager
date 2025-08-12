public class Functions
{
    public static void AddTaskFnc()
    {
        if (MainMenu.tasks.Count >= 5) { Console.Clear(); Console.WriteLine("You can have a max of 5 active tasks!"); }
        else
        {
            Console.Clear();
            Console.Write("Enter the task you want to add: ");
            string title = "" + Console.ReadLine();
            MainMenu.tasks.Add(new TaskItem(title));
            Console.WriteLine("Task added!");
        }
    }
    public static void ShowTasks()
    {
        Console.Clear();
        Console.WriteLine("Task list: ");
        if (MainMenu.tasks.Count == 0)
        {
            Console.WriteLine("No tasks found!");
        }
        else
        {
            for (int i = 0; i < MainMenu.tasks.Count; i++)
            {
                var status = MainMenu.tasks[i].Complete ? "[Done]" : "[Not done]";
                Console.Write($"{i + 1}. {MainMenu.tasks[i].TaskName}  ");
                Console.ForegroundColor = MainMenu.tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"  {status}\n");
                Console.ResetColor();

            }
        }
    }
    public static void MarkTask()
    {

        if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= MainMenu.tasks.Count)
        {
            if (MainMenu.tasks[number - 1].Complete == true)
            {
                Console.WriteLine("This task is already complete!");
            }
            else
            {
                MainMenu.tasks[number - 1].Complete = true;
                MainMenu.tasks = MainMenu.tasks.OrderBy(i => i.Complete).ToList();
                ShowTasks();
                Console.Write("Task marked as complete! Mark another or continue: ");
                MarkTask();
            }
        }
        else { MainMenu.continueTask = false; }
    }
    public static void RemoveTask()
    {
        if (int.TryParse(Console.ReadLine(), out int number2) && number2 >= 1 && number2 <= MainMenu.tasks.Count)
        {
            MainMenu.tasks.RemoveAt(number2 - 1);
            ShowTasks();
            Console.WriteLine("Task successfully removed! Remove another or continue: ");
            RemoveTask();
        }
        else { MainMenu.continueTask = false; }
    }
}