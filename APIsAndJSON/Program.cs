using System;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using APIsAndJSON;

namespace APIsAndJSO.Get
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Conversation between Kanye West and Ron Swanson.
            Console.WriteLine("Have you ever wondered what a conversation between Kanye West and Ron Swanson would sound like?");
            Console.WriteLine("Well, here you go!"); 
            for (int i = 0; i < 5; i++)
            {
                RonVSKanyeAPI.KanyeQuote();

                RonVSKanyeAPI.RonQuote();
            }

            Console.WriteLine();
            Console.WriteLine("Now that your head is spinning, let's change the subject LOL.");
            
            //Calling the OpenWeatherMap API to find the current temperature of a zip code.
            string key = System.IO.File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            bool repeat = true;
            do
            {
                Console.WriteLine("Please enter a zip code for the current temperature.");
                var zipCode = Console.ReadLine();

                var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIKey}";

                Console.WriteLine($"Current Temperature: {OpenWeatherMapAPI.GetTemp(apiCall)} °F");
                Console.WriteLine("--------");
                Console.WriteLine($"Would you like to check the current temperature in another zip code: Yes or No?");
   
                var anotherTemp = Console.ReadLine();
                if (anotherTemp.ToLower() == "yes")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            } while (repeat);
         
            Console.WriteLine("Ok, go and enjoy this beautiful day!"); 

        }
    }
}
