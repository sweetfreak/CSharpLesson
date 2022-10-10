using System;
using System.Collections.Generic;

//FOR C# HELP, SEE feature/csharp-syntax BRANCH!!
// C# uses double quotes!!

namespace CatWorx.BadgeMaker
{
    class Program 
    {
        static List<string>  GetEmployees() {
            //return a list of strings:
            List<string> employees = new List<string>(); // {"adam", "amy"};
            // employees.Add("barbara");
            // employees.Add("billy");

            //collect user vales until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter a name (leave empty to exit):");
                //get a name from the console and assign it to a variable
                //?? is a "null coalescing operator" - similar to ternary operator - will check for null and replace it with the value after the operator. Or... it's supposed to do that...
                string input = Console.ReadLine() ?? "";
                //break if the user hits ENTER without typing a name
                if (input == "")
                {
                    break;
                }
                employees.Add(input);
            }
                return employees;
        }

        static void PrintEmployees(List<string> employees) 
        {
             Console.WriteLine("The employees are as follows:");
            for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine(employees[i]);
                }
            
        }

        static void Main(string[] args)
        {
            List<string> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}