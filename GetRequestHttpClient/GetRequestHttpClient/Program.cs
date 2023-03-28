using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GetRequestHttpClient
{

    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=6fa095c114c44b8983cf448560847507";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse? weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            Console.WriteLine("t {0}: {1} C _timezona {2}", weatherResponse.Name, weatherResponse.Main.Temp,weatherResponse.timezone);
            Console.ReadLine();
        }
        //https://jsonformatter.org/json-pretty-print ссылка для декодирования url в json<-
    }
}