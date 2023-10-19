using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> tasks = new List<string>();
    static string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.WriteLine("správce uloh");
            Console.WriteLine("1. Přidat úkol");
            Console.WriteLine("2. Zobrazit úkoly");
            Console.WriteLine("3. Smazat úkol");
            Console.WriteLine("4. Uložit a ukončit");
            

            Console.Write("Vyber akci (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ShowTasks();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    SaveAndExit();
                    break;
                default:
                    Console.WriteLine("špatne bro. Zadej číslo od 1 do 4.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Název úkolu: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine("Úkol byl přidán.");
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Seznam úkolů je prázdný.");
            return;
        }

        Console.WriteLine(" Seznam úkolů");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
        Console.WriteLine("-----------------------------");
    }

    static void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Seznam úkolů je prázdný.");
            return;
        }

        ShowTasks();

        Console.Write("Zadej číslo úkolu k smazání: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Úkol byl smazán.");
        }
        else
        {
            Console.WriteLine("Takhle teda ne.");
        }
    }

    static void SaveAndExit()
    {
        SaveTasks();
        Console.WriteLine("Úkoly byly uloženy. Konec programu.");
        Environment.Exit(0);
    }

    static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }
}
