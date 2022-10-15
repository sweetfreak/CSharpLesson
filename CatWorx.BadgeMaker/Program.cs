using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//FOR C# HELP, SEE feature/csharp-syntax BRANCH!!
// C# uses double quotes!!

namespace CatWorx.BadgeMaker
{
    class Program 
    {
        

        async static Task Main(string[] args)
        {
            // List<Employee> employees =  PeopleFetcher.GetEmployees();
            List<Employee> employees = await PeopleFetcher.GetFromApi();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}