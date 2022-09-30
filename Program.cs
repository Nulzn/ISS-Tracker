using System;
using System.Net.Http;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;


namespace ISSTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var newAPI = new API();
            newAPI.runISS("https://api.wheretheiss.at/v1/satellites/25544");
        }
    }

    public class API
    {
        public void runCoordinates()
        {

        }
        public void runISS(string path)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(path);
                var result = client.GetAsync(endpoint).Result;
                var data = result.Content.ReadAsStringAsync().Result;
                dynamic jsonData = JObject.Parse(data);


                Console.WriteLine($"LAT: {jsonData.latitude} | LON: {jsonData.longitude}");

            }
        }
    }
}