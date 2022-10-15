using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker {
    class PeopleFetcher {

        public static List<Employee> GetEmployees() {
            //return a list of strings:
            List<Employee> employees = new List<Employee>(); // {"adam", "amy"};

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

    
        async public static Task<List<Employee>> GetFromApi() {
            List<Employee> employees = new List<Employee>();

            using(HttpClient client = new HttpClient()) {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                //Console.WriteLine(response);
                JObject json = JObject.Parse(response);
                // Console.WriteLine(json.SelectToken("results[0].name.first"));
                // Console.WriteLine(json.SelectToken("results[1].name.first"));
                // Console.WriteLine(json.SelectToken("results[2].name.first"));

               foreach (JToken token in json.SelectToken("results[i]")) {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }
            }

        

            return employees;
        }
    }
}