using System;
using ChatGPT_API_Lib;
using ChatGPT_API_Lib.BusinessLogic;

namespace ChatBotUI
{
    class Program
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        // fields
        public static string apiUrl = "https://api.openai.com/v1/chat/completions";
        public static string apiToken = "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";
        public static string modelType = "gpt-4-0314";
        public static int maxTokens = 256;
        public static double temperature = 1.0f;

        static async Task Main(string[] args)
        {

        }
    }
}