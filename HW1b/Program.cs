using System;
using System.Text;
using static System.Math;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;


public class Storeitems
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Cost { get; set; }
}


public class Program
{
    public static string[] columnHeaders;
    public static string textFilePath;
    public static char textDelimiter;

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome");


        textFilePath = "./../../../../Testing.txt";


        Console.WriteLine("Enter Text Delimiter (ex:,)");
        string textDelimiterLine = Console.ReadLine();
        textDelimiterLine = textDelimiterLine.Trim();
        textDelimiter = textDelimiterLine[0];

        List<Storeitems> storeitemss = ReadLinesFromTextFile(textFilePath, textDelimiter);

        // List<Storeitems> storeitemss = new List<Storeitems>();
        // storeitemss.Add(new Storeitems {Id=1, Name="Tomato", Description="Red", Category="vegetable", Cost=20});
        // storeitemss.Add(new Storeitems {Id=2, Name="Grape", Description="Smallfruit", Category="Fruit", Cost=17});
        // storeitemss.Add(new Storeitems {Id=3, Name="chlli", Description="Red", Category="vegetable", Cost=16});

        Console.WriteLine("Available Commands: \nprint - Print the entries,\nadd - Add an Entry,\nfilter - Filter existing entries,\nanalyze - Do some basic analysis,\nexit - Exit the app.\n !Note: Commands are case-insensitive.");
        while (true)
        {
            Console.WriteLine("Commands = [print, add, filter, analyze, exit]");
            Console.WriteLine("Enter Your Command: ");

            string command = Console.ReadLine();

            if (String.Equals(command, "print", StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < storeitemss.Count; i++)
                {
                    Console.WriteLine("{0}    {1}    {2}    {3}", storeitemss[i].Id, storeitemss[i].Name, storeitemss[i].Category, storeitemss[i].Cost);
                }
            }
            else if (String.Equals(command, "add", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Adding new Entry...");
                storeitemss = AddNewEntry(storeitemss);
                Console.WriteLine("Adding new Entry... Done.");
            }
            else if (String.Equals(command, "filter", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Filtering...");
                FilterStoreitemss(storeitemss);
                Console.WriteLine("Filtering... Done");
            }
            else if (String.Equals(command, "analyze", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Analyzing...");
                AnalyzeStoreitemss(storeitemss);
                Console.WriteLine("Analyzing... Done");
            }
            else if (String.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine("!!! Invalid Command Entered. Try Again. Hint: Check Spelling");
            }

        } // end of While

        Console.WriteLine("Writing the updated data...");
        WriteLinesToTextFile(storeitemss);
        Console.WriteLine("Writing the updated data... Done");

        Console.WriteLine("Exiting... Done");
    }

    public static List<Storeitems> AddNewEntry(List<Storeitems> storeitemss)
    {
        Storeitems newStoreitems = new Storeitems();
        Console.WriteLine("Storeitems Id: ");
        newStoreitems.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Storeitems Name: ");
        newStoreitems.Name = Console.ReadLine();

        Console.WriteLine("Storeitems Description: ");
        newStoreitems.Description = Console.ReadLine();

        Console.WriteLine("Storeitems Category: ");
        newStoreitems.Category = Console.ReadLine();

        Console.WriteLine("Storeitems Cost: ");
        newStoreitems.Cost = decimal.Parse(Console.ReadLine());

        storeitemss.Add(newStoreitems);

        return storeitemss;
    }

    public static void FilterStoreitemss(List<Storeitems> storeitemss)
    {
        Console.WriteLine("You can filter by : \nname - Filter by Name,\ncategory - Filter by Category");
        string filterBy = Console.ReadLine();
        if (String.Equals(filterBy, "name", StringComparison.OrdinalIgnoreCase))
        {
            // filter by Name and return results
            Console.WriteLine("Enter value for Name: (case-insensitive matching)");
            string value = Console.ReadLine();

            for (int i = 0; i < storeitemss.Count; i++)
            {
                if (String.Equals(storeitemss[i].Name, value, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("{0}    {1}    {2}    {3}", storeitemss[i].Id, storeitemss[i].Name, storeitemss[i].Category, storeitemss[i].Cost);
                }
            }
        }
        else if (String.Equals(filterBy, "category", StringComparison.OrdinalIgnoreCase))
        {
            // filter by category and return results
            Console.WriteLine("Enter value for Category: (case-insensitive matching)");
            string value = Console.ReadLine();

            for (int i = 0; i < storeitemss.Count; i++)
            {
                if (String.Equals(storeitemss[i].Category, value, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("{0}    {1}    {2}    {3}", storeitemss[i].Id, storeitemss[i].Name, storeitemss[i].Category, storeitemss[i].Cost);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid option entered. Try Again. Hint: Check Spelling.");
        }
    }

    public static void AnalyzeStoreitemss(List<Storeitems> storeitemss)
    {
        Console.WriteLine("You can do: \nsum - Sum the Cost,\navg - Avg the Cost");

        Console.WriteLine("Enter your command: ");
        string command = Console.ReadLine();

        if (String.Equals(command, "sum", StringComparison.OrdinalIgnoreCase))
        {
            decimal total = 0m;
            for (int i = 0; i < storeitemss.Count; i++)
            {
                total += storeitemss[i].Cost;
            }
            Console.WriteLine("Total Sum of Cost = {0}", total);
        }
        else if (String.Equals(command, "avg", StringComparison.OrdinalIgnoreCase))
        {
            decimal total = 0m;
            for (int i = 0; i < storeitemss.Count; i++)
            {
                total += storeitemss[i].Cost;
            }
            Console.WriteLine("Total Average of Cost = {0}", Math.Round(total / storeitemss.Count), 2);
        }
        else
        {
            Console.WriteLine("Invalid command entered. Try Again. Hint: Check Spelling");
        }
    }

    public static List<Storeitems> ReadLinesFromTextFile(string filePath, char delimiter)
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);
        columnHeaders = lines[0].Split(delimiter);

        List<Storeitems> storeitemss = new List<Storeitems>();

        bool skip = true;
        int count = 0;

        foreach (string line in lines)
        {
            if (count > 0)
            {

                if (skip)
                {
                    skip = false;
                }
                //3.1 Instantiate the resulting dictionary
                var newStoreitems = new Storeitems();

                //3.2 Split the data
                var cells = line.Split(delimiter);

                //3.3 Add an entry for each retrieved header.
                for (int i = 0; i < columnHeaders.Length; i++)
                {
                    if (String.Equals(columnHeaders[i], "Id", StringComparison.OrdinalIgnoreCase))
                    {
                        newStoreitems.Id = int.Parse(cells[i]);
                    }
                    else if (String.Equals(columnHeaders[i], "Name", StringComparison.OrdinalIgnoreCase))
                    {
                        newStoreitems.Name = cells[i];
                    }
                    else if (String.Equals(columnHeaders[i], "Description", StringComparison.OrdinalIgnoreCase))
                    {
                        newStoreitems.Description = cells[i];
                    }
                    else if (String.Equals(columnHeaders[i], "Category", StringComparison.OrdinalIgnoreCase))
                    {
                        newStoreitems.Category = cells[i];
                    }
                    else if (String.Equals(columnHeaders[i], "Cost", StringComparison.OrdinalIgnoreCase))
                    {
                        newStoreitems.Cost = decimal.Parse(cells[i]);
                    }
                }
                storeitemss.Add(newStoreitems);
            }
            count += 1;
        }

        // return the storeitemss
        return storeitemss;
    }

    public static void WriteLinesToTextFile(List<Storeitems> storeitemss)
    {
        StringBuilder csv = new StringBuilder();

        for (int i = 0; i < storeitemss.Count; i++)
        {
            string line = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", storeitemss[i].Id, textDelimiter, storeitemss[i].Name, textDelimiter, storeitemss[i].Description, textDelimiter, storeitemss[i].Category, textDelimiter, storeitemss[i].Cost);
            csv.AppendLine(line);
        }

        Console.WriteLine(csv.ToString());
        System.IO.File.WriteAllText(textFilePath, csv.ToString());
    }
}
