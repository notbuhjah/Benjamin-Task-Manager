using System;
using System.Collections.Generic;

public class MainMenu
{
    // Global list storing all current tasks
    public static List<TaskItem> tasks = new List<TaskItem>();

    // Boolean flag (currently unused in this code snippet, may be for future use)
    public static bool TrueMark;

    // Controls whether the program should continue waiting for user interaction
    public static bool continueTask = true;

    // Main menu loop method
    public static void MMenu()
    {
        // Load saved tasks from file when program starts
        Functions.LoadTasks();

        bool True = true; // Controls the main menu loop
        while (True)
        {
            // Clear console and display the main menu
            Console.Clear();
            Console.WriteLine("   Task Manager   ");
            Console.WriteLine("1. New task");
            Console.WriteLine("2. Show tasks");
            Console.WriteLine("3. Mark task");
            Console.WriteLine("4. Remove task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            // Read user input
            string chosen = "" + Console.ReadLine();

            // Reset task continuation flag before each action
            continueTask = true;
            
            // Execute the chosen menu option
            switch (chosen)
            {
                case "1":
                    // Add a new task
                    Functions.AddTaskFnc();
                    break;
                case "2":
                    // Display all tasks
                    Functions.ShowTasks();
                    break;
                case "3":
                    // Display tasks and allow user to mark one as complete
                    Functions.ShowTasks();
                    Console.Write("Enter the number you want to mark as complete: ");
                    Functions.MarkTask();
                    break;
                case "4":
                    // Display tasks and allow user to remove one
                    Functions.ShowTasks();
                    Console.Write("Enter the number of the task you want to remove: ");
                    Functions.RemoveTask();
                    break;
                case "5":
                    // Exit the program
                    True = false;
                    continueTask = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    // If invalid option, skip waiting for user input
                    continueTask = false;
                    break;
            }

            // Save tasks to file after every action
            Functions.SaveTaskFile();

            // Pause before continuing, unless a task process was interrupted
            if (continueTask)
            {
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
            }
        }
    }
}
