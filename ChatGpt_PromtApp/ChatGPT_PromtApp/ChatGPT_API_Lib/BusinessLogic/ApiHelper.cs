using System.Net.Http;
using System.Net.Http.Headers;

public class ApiHelper
{
    public static HttpClient BotClient { get; set; }

    public static void InitializeClient(string apiKey)
    {
        BotClient = new HttpClient
        {
            BaseAddress = new System.Uri("https://api.openai.com/v1/")
        };

        BotClient.DefaultRequestHeaders.Accept.Clear();
        BotClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        BotClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }
}

