using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUI.ViewModels
{
    public class RTxtBoxViewModel : Screen
    {
        private string _displayText = "Hallo Welt!";

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
            }
        }
    }
}
