using System;
using System.Collections.Generic;
public class MainMenu
{
    public static List<TaskItem> tasks = new List<TaskItem>();
    public static bool TrueMark;
    public static bool continueTask = true;
    public static void MMenu()
    {
        Functions.LoadTasks();
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
            continueTask = true;
            
            switch (chosen)
            {
                case "1":
                    Functions.AddTaskFnc();
                    break;
                case "2":
                    Functions.ShowTasks();
                    break;
                case "3":
                    Functions.ShowTasks();
                    Console.Write("Enter the number you want to mark as complete: ");
                    Functions.MarkTask();
                    break;
                case "4":
                    Functions.ShowTasks();
                    Console.Write("Enter the number of the task you want to remove: ");
                    Functions.RemoveTask();
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
            Functions.SaveTaskFile();
            if (continueTask)
            {
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
            }
        }
    }
}