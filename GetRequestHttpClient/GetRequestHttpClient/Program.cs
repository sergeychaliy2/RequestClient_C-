using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GetRequestHttpClient
{

    class Program
    {
        // private static HttpClient httpClient = new HttpClient();
        // static void GetHttpClient(string[] args)
        // {
        //     string url = "https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=6fa095c114c44b8983cf448560847507";
        //     HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //     HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //     string response;
        //     using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        //     {
        //         response = streamReader.ReadToEnd();
        //     }
        //
        //     WeatherResponse? weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
        //     Console.WriteLine("t {0}: {1} C _timezona {2}", weatherResponse.Name, weatherResponse.Main.Temp,weatherResponse.timezone);
        //     Console.ReadLine();
        // }
        //https://jsonformatter.org/json-pretty-print ссылка для декодирования url в json<-
        static HttpClient httpClient = new HttpClient();
        static async Task Main()
        {
            StringContent content = new StringContent("Tom");
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7094/data");
            request.Content = content;
            using var response = await httpClient.SendAsync(request);//send
            string responseText = await response.Content.ReadAsStringAsync();//getResponse
            Console.WriteLine(responseText);
        }
    }
    
}