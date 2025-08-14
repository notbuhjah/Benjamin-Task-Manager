using System.Text.Json;
using Microsoft.AspNetCore.Components;

public class Functions
{
    // File path where tasks will be stored in JSON format
    public static string filepath = "tasks.json";

    // Temporary variable to store the chosen day of the week when adding tasks
    public static DayOfWeek dayofweek;

    // Adds a new task to the task list
    public static void AddTaskFnc()
    {
        // Limit: no more than 5 active tasks allowed
        if (MainMenu.tasks.Count >= 5) 
        { 
            Console.Clear(); 
            Console.WriteLine("You can have a max of 5 active tasks!"); 
        }
        else
        {
            Console.Clear();
            
            // Prompt for task name
            Console.Write("Enter the task you want to add: ");
            string title = "" + Console.ReadLine();

            // Prompt for the weekday the task should be done by
            Console.Write("\nEnter the weekday the task should be done by(sorts by sunday first): ");
            string weekdayInput = "" + Console.ReadLine();
            string weekday = weekdayInput.ToLower();

            // Convert user input string to DayOfWeek enum
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

            // Add new task with title and weekday
            MainMenu.tasks.Add(new TaskItem(title, dayofweek));
            Console.WriteLine("Task added!");

            // Sort tasks: first by weekday, then by completion status
            MainMenu.tasks = MainMenu.tasks
                .OrderBy(i => i.Weekday)
                .ThenBy(i => i.Complete)
                .ToList();
        }
    }

    // Displays all tasks in the console
    public static void ShowTasks()
    {
        Console.Clear();
        Console.WriteLine("Task list: ");

        // If there are no tasks, inform the user
        if (MainMenu.tasks.Count == 0)
        {
            Console.WriteLine("No tasks found!");
        }
        else
        {
            // Loop through all tasks and display them with formatting
            for (int i = 0; i < MainMenu.tasks.Count; i++)
            {
                var status = MainMenu.tasks[i].Complete ? "[Done]" : "[Not done]";
                var whatday = MainMenu.tasks[i].Weekday;

                Console.Write($"{i + 1}. {MainMenu.tasks[i].TaskName}  ");

                // Change text color depending on completion status
                Console.ForegroundColor = MainMenu.tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"  {status}  ");
                Console.ResetColor();

                // Show the target weekday for the task
                Console.Write($"  To be done by: {whatday}\n");
            }
        }
    }

    // Marks a selected task as complete
    public static void MarkTask()
    {
        // Parse user input and check if it's a valid task number
        if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= MainMenu.tasks.Count)
        {
            // If the task is already complete, inform the user
            if (MainMenu.tasks[number - 1].Complete == true)
            {
                Console.WriteLine("This task is already complete!");
            }
            else
            {
                // Mark task as complete
                MainMenu.tasks[number - 1].Complete = true;

                // Resort tasks after status change
                MainMenu.tasks = MainMenu.tasks
                    .OrderBy(i => i.Weekday)
                    .ThenBy(i => i.Complete)
                    .ToList();

                // Show updated task list
                ShowTasks();

                Console.Write("Task marked as complete! Mark another or continue: ");

                // Recursively allow marking another task
                MarkTask();
            }
        }
        else 
        { 
            // End marking process if input is invalid
            MainMenu.continueTask = false; 
        }
    }

    // Removes a task from the list
    public static void RemoveTask()
    {
        // Parse user input and check if it's a valid task number
        if (int.TryParse(Console.ReadLine(), out int number2) && number2 >= 1 && number2 <= MainMenu.tasks.Count)
        {
            // Remove selected task
            MainMenu.tasks.RemoveAt(number2 - 1);

            // Show updated task list
            ShowTasks();
            Console.WriteLine("Task successfully removed! Remove another or continue: ");

            // Recursively allow removing another task
            RemoveTask();
        }
        else 
        { 
            // End removing process if input is invalid
            MainMenu.continueTask = false; 
        }
    }

    // Saves the current task list to a JSON file
    public static void SaveTaskFile()
    {
        string json = JsonSerializer.Serialize(MainMenu.tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filepath, json);
    }

    // Loads tasks from the JSON file if it exists
    public static void LoadTasks()
    {
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);

            if (!string.IsNullOrWhiteSpace(json))
            {
                // Deserialize JSON into the tasks list
                MainMenu.tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                MainMenu.tasks = new List<TaskItem>();
            }
        }
        else
        {
            // If file does not exist, start with an empty list
            MainMenu.tasks = new List<TaskItem>();
        }
    }
}
