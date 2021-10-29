using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIsandJASON
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("KanyeQuote\n-----------------------\n");
                KanyeQuoteGenerator();

                Console.WriteLine("RonQuote\n---------------------\n");
                RonQuoteGenerator();
            }
            var response = CallOfDuty();
            Console.WriteLine(response.Content);
        }
        public static void KanyeQuoteGenerator()
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            
                Console.WriteLine(kanyeQuote);
                Console.WriteLine("\n");

            
        }
        public static void RonQuoteGenerator()
        {

            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            
                Console.WriteLine(ronQuote);
                Console.WriteLine("\n");
            
           
        }
        public static IRestResponse CallOfDuty()
        {
            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone-matches/Amartin743/psn");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "call-of-duty-modern-warfare.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "65031c156amsh26a3934ff09dbf0p135b24jsnc3604e20ec71");
            IRestResponse response = client.Execute(request);
            return response;
        }

    }
}
