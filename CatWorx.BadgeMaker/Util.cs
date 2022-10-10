using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker {

    class Util {

        //method declared as "static"
        public static void PrintEmployees(List<Employee> employees)  {
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

        public static void MakeCSV(List<Employee> employees) {

            //check if "data" folder exists - if it doesn't, create it
            if (!Directory.Exists("data")) {
                Directory.CreateDirectory("data");
            }

            //use System.IO.StreamWriter to create a CSV file
            //write "using" so it disposes the StreamWriter Object after using it
            using (StreamWriter file = new StreamWriter("data/employees.csv")) {
                file.WriteLine("ID,Name,PhotoUrl");

                //loop over employees
                for (int i=0; i < employees.Count; i++) {
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }

            }
        }
    }

}