using System.Data.Common;
using System.Globalization;
using System.Text.RegularExpressions;

Console.WriteLine("Input your name ");
string name = Console.ReadLine();

 
 DateTime birthdate;
        while (true)
        {
            Console.Write("Enter your birthdate (MM/dd/yyyy): ");
            string birthdateInput = Console.ReadLine();

            
            if (Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
            {
                
                birthdate = DateTime.ParseExact(birthdateInput, "MM/dd/yyyy", null);
                break;
            }
            else
            {
                Console.WriteLine("Error: Invalid date format. Please use MM/dd/yyyy.");
            }
        }

        
        int yage = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.DayOfYear < birthdate.DayOfYear) yage--; 
        Console.WriteLine($"Hello {name}, you are {yage} years old.");

       
        string filePath = "user_info.txt";
        File.WriteAllText(filePath, $"Name: {name} Birthdate: {birthdate.ToShortDateString()} Age: {yage}");
        Console.WriteLine("User information saved to user_info.txt");

        
        string fileContent = File.ReadAllText(filePath);
        Console.WriteLine("Content of user_info.txt:");
        Console.WriteLine(fileContent);

        
        Console.Write("Enter a directory for to list its files: ");
        string directoryPath = Console.ReadLine();

    
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("Files in the directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("Error: Directory does not exist.");
        }

        
        Console.Write("Enter a string to format to Title Case: ");
        string inputString = Console.ReadLine();
        string titleCaseString = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputString.ToLower());
        Console.WriteLine($"Formatted String: {titleCaseString}");

        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage Collection triggered explicitly.");

