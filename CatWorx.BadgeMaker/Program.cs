using System;
using System.Collections.Generic;

//FOR C# HELP, SEE feature/csharp-syntax BRANCH!!
// C# uses double quotes!!

namespace CatWorx.BadgeMaker
{
    class Program 
    {
        static List<Employee> GetEmployees() {
            //return a list of strings:
            List<Employee> employees = new List<Employee>(); // {"adam", "amy"};
            // employees.Add("barbara");
            // employees.Add("billy");

            //collect user vales until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter employee's first name (leave empty to exit):");
                //get a name from the console and assign it to a variable
                //?? is a "null coalescing operator" - similar to ternary operator - will check for null and replace it with the value after the operator. Or... it's supposed to do that...
                string firstName = Console.ReadLine() ?? "";
                //break if the user hits ENTER without typing a name
                if (firstName == "")
                {
                    break;
                }
                
                Console.Write("Please enter employee's last name: ");
                string lastName = Console.ReadLine() ?? "";

                Console.Write("Please Enter Employee ID: ");
                    //Parse to turn ReadLine input into an int
                int id = Int32.Parse(Console.ReadLine() ?? "");

                Console.Write("Please enter Photo URL: ");
                string photoUrl = Console.ReadLine() ?? "";

                //new employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                
                employees.Add(currentEmployee);
            }
                return employees;
        }

        static void PrintEmployees(List<Employee> employees) 
        {
             Console.WriteLine("The employees are as follows:");
            for (int i = 0; i < employees.Count; i++)
                {
                    string template ="{0,-10}\t{1,-20}\t{2}";
                      // each item in employees is now an Employee instance
                      // string format with template formatting check
                      // basically, offers a template for how to space everything out, then it places each argument in, based on the padding
                      Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
	                }
            
        }

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}