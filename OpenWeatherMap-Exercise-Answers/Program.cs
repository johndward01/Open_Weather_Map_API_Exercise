using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMap_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //// TODO: Create an instance of the HttpClient Class called client
            var client = new HttpClient();

            //// TODO: Ask for the users API Key and store that in a variable called "api_Key"


            //// TODO: Ask the user for their city name and store that in a variable called "city_name"
            //Console.WriteLine();
            //Console.Write("Please enter the city name: ");
            //var city_name = Console.ReadLine();
            //Console.WriteLine();

            //// TODO: Create a variable to store the URL (use String Interpolation for the {city_name} and {api_Key}  HINT: Make sure to use the "imperial" measurement endpoint
            //var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";

            //// TODO: Create a variable to store the response from your GET request to that URL from above  HINT: Don't forget to call .Result 
            //var response = client.GetStringAsync(weatherURL).Result;

            //// TODO: Create a variable to store the formattedResponse after you JObject.Parse() the response from above
            //var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

            //// TODO: Write out the current temperature in degrees Fahrenheit
            //Console.WriteLine($"The current Temperature is {JObject.Parse(formattedResponse).GetValue("temp")} degrees Fahrenheit");

            Console.Write("Please enter your API Key: ");
            var api_Key = Console.ReadLine();

            while (true)
            {
                AddSpaces(1);
                Console.Write("Please enter the city name: ");
                var city_name = Console.ReadLine();
                AddSpaces(1);

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine($"The current Temperature is {JObject.Parse(formattedResponse).GetValue("temp")} degrees Fahrenheit");
                AddSpaces(2);
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();
                AddSpaces(2);

                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }

            }
        }


        private static void AddSpaces(int numberOfSpaces)
        {
            while (numberOfSpaces != 0)
            {
                Console.WriteLine();
                numberOfSpaces--;
            }
        }
    }
}
