using System;
//this is no longer needed in NET 6.0/
//The following are also not needed:

// using System.IO;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Threading;
// using System.Threading.Tasks;

//needed for dictionaries:
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program 
    {
        //Main() MUST be nested in a class
        //void signifies that the return of this executable method will be void 
        //static keyword implies the the scope of this method is at class level, not object level, and can be invoked w/o having to create a new class instance. in other words, Main() can be run as soon as the program runs
        static void Main(string[] args) //entry point with parameters
        {

        //VARIABLES    
            // string greeting = "Hello";
            // greeting = greeting + " World";
            // Console.WriteLine($"greeting: {greeting}");
            // Console.WriteLine("~~~~~~~~~");
            // Console.WriteLine("greeting: {0}", greeting);

            // float side = 3.14f;
            // float area = side * side;
            // Console.WriteLine("area: {0}", area);
            // Console.WriteLine("area is a {0}", area.GetType()); // it's a System.Single


        //MATH
            // Console.WriteLine(2 * 3); // Basic Arithmetic: +, -, /, *
            // Console.WriteLine(10 % 3); // Modulus Op => remainder of 10/3
            // Console.WriteLine(1 + 2 * 3); // order of operations
            // Console.WriteLine(10 / 3.0); // int's and doubles
            // Console.WriteLine(10 / 3);  // int's 
            // Console.WriteLine("12" + "3");  // What happens here?

            // int num = 10;
            // num += 100;
            // Console.WriteLine(num);
            // num ++;
            // Console.WriteLine(num);




        //BOOL
            // bool isCold = true;
            // Console.WriteLine(isCold ? "drink" : "add ice");

            // Console.WriteLine(!isCold ? "drink" : "add ice");    


        //CONVERT
            // string stringNum = "2";
            // int intNum = Convert.ToInt32(stringNum);
            // Console.WriteLine(intNum);
            // Console.WriteLine(intNum.GetType()); // type is System.Int32


        //DICTIONARIES
        //added using.System.Collections.Generic;
            //dictionary's key-value pair types are declared in angled brackets - <string, double> or <int, string>

            // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>();

            // //to populate dictionary, use Add()
            // myScoreBoard.Add("firstInning", 10);
            // myScoreBoard.Add("secondInning", 20);
            // myScoreBoard.Add("thirdInning", 30);
            // myScoreBoard.Add("fourthInning", 40);
            // myScoreBoard.Add("fifthInning", 50);

            //OR WE CAN DO:
            // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(){
            // { "firstInning", 10 },
            // { "secondInning", 20},
            // { "thirdInning", 30},
            // { "fourthInning", 40},
            // { "fifthInning", 50}
            // };

            //Scoreboard Dictionary Example
            // Console.WriteLine("----------------");
            // Console.WriteLine("  Scoreboard");
            // Console.WriteLine("----------------");
            // Console.WriteLine("Inning |  Score");
            // Console.WriteLine("   1   |    {0}", myScoreBoard["firstInning"]);
            // Console.WriteLine("   2   |    {0}", myScoreBoard["secondInning"]);
            // Console.WriteLine("   3   |    {0}", myScoreBoard["thirdInning"]);
            // Console.WriteLine("   4   |    {0}", myScoreBoard["fourthInning"]);
            // Console.WriteLine("   5   |    {0}", myScoreBoard["fifthInning"]);

        // //ARRAYS
        //     string[] favFoods = new string[3]{ "pizza", "doughnuts", "ice cream"};
        //     string firstFood = favFoods[0];    
        //     string secondFood = favFoods[1];    
        //     string thirdFood = favFoods[2];    

        //     Console.WriteLine("I like {0}, {1}, add {2}", firstFood, secondFood, thirdFood);
        
        // //LISTS
        // //requires "using system.Collections.Generic;"

            List<string> employees = new List<string>  {"adam", "amy"};

            employees.Add("barbara");
            employees.Add("billy");

        //     Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
        
        // //LOOPS
        // //use the list<string> from above
        //     for (int i=0; i < employees.Count; i++) 
        //     {
        //         Console.WriteLine(employees[i]);
        //     }
        
//test

        }
    }
}