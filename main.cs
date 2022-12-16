using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode forecastNode = JsonNode.Parse(response)!;
        // Console.WriteLine(forecastNode);
        JsonNode weatherNode = forecastNode!["weather"][0]!;
        JsonNode main = forecastNode!["main"]!;
        JsonNode wind = forecastNode!["wind"]!;
        // Console.WriteLine(weatherNode);
        JsonNode descriptionNode = weatherNode!["description"]!;
        JsonNode temp = main!["temp"]!;
        JsonNode feelsLike = main!["feels_like"]!;
        JsonNode speed = wind!["speed"]!;
        Console.WriteLine("it is: " + descriptionNode);
        Console.WriteLine("temperature: " + temp + " k");
        Console.WriteLine("feels like: " + feelsLike);
        Console.WriteLine("wind speed: " + speed);
    }
}