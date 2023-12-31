﻿using API_Lib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API_Lib
{
    public class TicketProcessor
    {
        //public string apiUrl = "http://192.168.150.151";
        //public string apiToken = "NeCpzB3EXJCZNLck-CKNbWK8sZ-BhK59mPrhpsVilAN8M22xbeAr9_xiqKLcY-ZB";

        private static TicketProcessor _instance;

        public static TicketProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketProcessor();
                }
                return _instance;
            }
        }

        // ticket > id
        public async Task<TicketModel> LoadTicket(int ticketId,string apiUrl, string apiToken)
        {
            if (ticketId <= 0)
                throw new ArgumentException("Invalid ticket ID. Ticket ID must be greater than 0.");

            string url = $"{apiUrl}/api/v1/tickets/{ticketId}?expand=true";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        TicketModel ticket = await response.Content.ReadAsAsync<TicketModel>();
                        await Console.Out.WriteLineAsync("####### Ticket loaded ########");
                        return ticket;
                    }
                    else
                    {
                        throw new Exception($"Failed to load ticket. Status code: {response.StatusCode}");
                    }
                }
            }
        }

        // ticket > list > datagrid
        public async Task<List<TicketModel>> LoadTickets(string apiUrl, string apiToken)
        {
            string url = $"{apiUrl}/api/v1/tickets?expand=true";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ticketsJson = await response.Content.ReadAsStringAsync();
                        List<TicketModel> tickets = JsonConvert.DeserializeObject<List<TicketModel>>(ticketsJson);
                        return tickets;
                    }
                    else
                    {
                        throw new Exception($"Failed to load tickets. Status code: {response.StatusCode}");
                    }
                }
            }
        }

        // article
        // load article > id
        public async Task<List<ArticleModel>> LoadArticles(int ticketId, string apiUrl, string apiToken)
        {
            string url = $"{apiUrl}/api/v1/ticket_articles/by_ticket/{ticketId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ticketsJson = await response.Content.ReadAsStringAsync();
                        List<ArticleModel> articles = JsonConvert.DeserializeObject<List<ArticleModel>>(ticketsJson);
                        return articles;
                    }
                    else
                    {
                        throw new Exception($"Failed to load articles. Status code: {response.StatusCode}");
                    }
                }
            }
        }
    }
}
