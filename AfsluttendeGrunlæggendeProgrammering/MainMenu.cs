using System;
using System.Collections.Generic;
public class MainMenu
{
    public static void MMenu()
    {
        List<TaskItem> tasks = new List<TaskItem>();
        bool True = true;
        while (True)
        {
            Console.Clear();
            Console.WriteLine("   Task Manager   ");
            Console.WriteLine("1. New task");
            Console.WriteLine("2. Show tasks");
            Console.WriteLine("3. Mark task");
            Console.WriteLine("4. Remove task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string chosen = "" + Console.ReadLine();
            bool continueTask = true;

            switch (chosen)
            {
                case "1":
                    if (tasks.Count >= 5) { Console.Clear(); Console.WriteLine("You can have a max of 5 active tasks!"); }
                    else
                    {
                        Console.Clear();
                        Console.Write("Enter the task you want to add: ");
                        string title = "" + Console.ReadLine();
                        tasks.Add(new TaskItem(title));
                        Console.WriteLine("Task added!");
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Task list: ");
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks found!");
                    }
                    else
                    {
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            var status = tasks[i].Complete ? "[Done]" : "[Not done]";
                            Console.Write($"{i + 1}. {tasks[i].TaskName}  ");
                            Console.ForegroundColor = tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.Write($"  {status}\n");
                            Console.ResetColor();

                        }
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter the number of the task you want to mark as complete: ");
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks found!");
                    }
                    else
                    {
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            var status = tasks[i].Complete ? "[Done]" : "[Not done]";
                            Console.Write($"{i + 1}. {tasks[i].TaskName}  ");
                            Console.ForegroundColor = tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.Write($"  {status}\n");
                            Console.ResetColor();
                        }
                    }
                    if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= tasks.Count)
                    {
                        if (tasks[number - 1].Complete == true)
                        {
                            Console.WriteLine("This task is already complete!");
                        }
                        else
                        {
                            tasks[number - 1].Complete = true;
                            Console.WriteLine("Task marked as complete!");
                            tasks = tasks.OrderBy(i => i.Complete).ToList();
                        }
                    }
                    else { Console.WriteLine("Invalid number!"); }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter the number of the task you want to remove: ");
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks found!");
                    }
                    else
                    {
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            var status = tasks[i].Complete ? "[Done]" : "[Not done]";
                            Console.Write($"{i + 1}. {tasks[i].TaskName}  ");
                            Console.ForegroundColor = tasks[i].Complete ? ConsoleColor.Green : ConsoleColor.Red;
                            Console.Write($"  {status}\n");
                            Console.ResetColor();
                        }
                    }
                    if (int.TryParse(Console.ReadLine(), out int number2) && number2 >= 1 && number2 <= tasks.Count)
                    {
                        tasks.RemoveAt(number2 - 1);
                        Console.WriteLine("Task successfully removed!");
                    }
                    else { Console.WriteLine("Invalid number!"); }
                    break;
                case "5":
                    True = false;
                    continueTask = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    continueTask = false;
                    break;
            }

            if (continueTask)
            {
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
            }
        }
    }
}