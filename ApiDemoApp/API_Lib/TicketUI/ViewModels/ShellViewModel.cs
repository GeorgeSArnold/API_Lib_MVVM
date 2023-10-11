using Caliburn.Micro;

namespace TicketUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
        }

        // load views
        public void LoadTicket()
        {
            ActivateItemAsync(new TicketViewModel());
        }
        public void LoadArticle()
        {
            ActivateItemAsync(new ArticleViewModel());
        }
        public void LoadConnection()
        {
            ActivateItemAsync(new ConnectionViewModel());
        }
        public void LoadTable()
        {
            ActivateItemAsync(new TableViewModel());
        }
        public void LoadRTxtBox()
        {
            ActivateItemAsync(new RTxtBoxViewModel());
        }
        public void LoadChatGpt()
        {
            ActivateItemAsync(new ChatGptViewModel());
        }
    }
}