using System;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        //Method to get the current temperature of a zip code.
        public static double GetTemp(string apiCall)
        {
            var client = new HttpClient();

            var openWeatherResponse = client.GetStringAsync(apiCall).Result;

            var temp = double.Parse(JObject.Parse(openWeatherResponse)["main"]["temp"].ToString());

            return temp;

        }
    }
}
