namespace WebServices;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServices.Models;



public interface IServiceProcessor
{
    public Task<string?> CallApi(string requestApiUrl);
}

class ServiceProcessor : IServiceProcessor
{
    // static async Task Main()
    // {
    //     // Replace the URL with the actual API endpoint you want to call
    //     string apiUrl = "https://api.example.com/data";

    //     // Call the API and get the response as a string
    //     string apiResponse = await CallApi(apiUrl);

    //     // Display the API response
    //     Console.WriteLine(apiResponse);
    // }

    public async Task<string?> CallApi(string requestApiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Make the GET request to the API
                HttpResponseMessage response = await client.GetAsync(requestApiUrl);

                // Ensure the request was successful (status code 200)
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that occurred during the API call
                Console.WriteLine($"Error calling the API: {ex.Message}");
                return null;
            }
        }
    }

    public static Person? Deserialize(string content)
    {
        // Read the response content as a string
                
                var parsed = Person.FromJson(content);
                //var parsed = JsonConvert.DeserializeObject<Person>(content);
                return parsed;
    }

    
}
