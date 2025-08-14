using System.Text.Json;
using Microsoft.AspNetCore.Components;

public class Functions
{
    public static string filepath = "tasks.json";
    public static DayOfWeek dayofweek;
    public static void AddTaskFnc()
    {
        if (MainMenu.tasks.Count >= 5) { Console.Clear(); Console.WriteLine("You can have a max of 5 active tasks!"); }
        else
        {
            Console.Clear();
            Console.Write("Enter the task you want to add: ");
            string title = "" + Console.ReadLine();
            Console.Write("\nEnter the weekday the task should be done by(sorts by sunday first): ");
            string weekdayInput = "" + Console.ReadLine();
            string weekday = weekdayInput.ToLower();

            switch (weekday)
            {
                case "monday":
                    dayofweek = DayOfWeek.Monday;
                    break;
                case "tuesday":
                    dayofweek = DayOfWeek.Tuesday;
                    break;
                case "wednesday":
                    dayofweek = DayOfWeek.Wednesday;
                    break;
                case "thursday":
                    dayofweek = DayOfWeek.Thursday;
                    break;
                case "friday":
                    dayofweek = DayOfWeek.Friday;
                    break;
                case "saturday":
                    dayofweek = DayOfWeek.Saturday;
                    break;
                case "sunday":
                    dayofweek = DayOfWeek.Sunday;
                    break;
            }
            MainMenu.tasks.Add(new TaskItem(title, dayofweek));
            Console.WriteLine("Task added!");

            MainMenu.tasks = MainMenu.tasks.OrderBy(i => i.Weekday).ThenBy(i => i.Complete).ToList();
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
                var whatday = MainMenu.tasks[i].Weekday;
                Console.Write($"{i + 1}. {MainMenu.tasks[i].TaskName}  ");
                Console.ForegroundColor = MainMenu.tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"  {status}  ");
                Console.ResetColor();
                Console.Write($"  To be done by: {whatday}\n");
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
                MainMenu.tasks = MainMenu.tasks.OrderBy(i => i.Weekday).ThenBy(i => i.Complete).ToList();
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
    public static void SaveTaskFile()
    {
        string json = JsonSerializer.Serialize(MainMenu.tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filepath, json);
    }
    public static void LoadTasks()
    {
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);

            if (!string.IsNullOrWhiteSpace(json))
            {
                MainMenu.tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                MainMenu.tasks = new List<TaskItem>();
            }
        }
        else
        {
            MainMenu.tasks = new List<TaskItem>();
        }
    }

}