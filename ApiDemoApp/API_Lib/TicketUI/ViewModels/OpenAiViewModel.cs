using Bot_Lib.Services;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUI.ViewModels
{
    public class OpenAiViewModel : Screen
    {
        // txtBoxes fields
        private string request;
        public string Request
        {
            get { return request; }
            set 
            { 
                request = value;
                NotifyOfPropertyChange(() => Request);
            }
        }
        private string response;
        public string Response
        {
            get { return response; }
            set 
            { 
                response = value;
                NotifyOfPropertyChange(() => Response);
            }
        }

        // method click
        public async Task GetCompletions(string Request)
        {
            await Console.Out.WriteLineAsync("---> send btn clicked <---");
            try
            {
                ConnectionViewModel cvm = new ConnectionViewModel();
                string apiToken = cvm.GetGptToken();
                OpenAiService openAiService = OpenAiService.GetInstance(apiToken);

                await Console.Out.WriteLineAsync("---> sending promt --->");
                string completion = await openAiService.GetCompletions(Request);
                await Console.Out.WriteLineAsync("<--- get completion <---");

                Console.WriteLine("Response: " + completion);

                await Console.Out.WriteLineAsync("---> complation > Response prop <---");
                Response = completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
