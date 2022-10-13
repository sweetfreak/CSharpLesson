using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//FOR C# HELP, SEE feature/csharp-syntax BRANCH!!
// C# uses double quotes!!

namespace CatWorx.BadgeMaker
{
    class Program 
    {
        

        // static void PrintEmployees(List<Employee> employees) {
        //   Console.WriteLine("The employees are as follows:");
        //      }

        async static Task Main(string[] args)
        {
            List<Employee> employees = await PeopleFetcher.GetEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}