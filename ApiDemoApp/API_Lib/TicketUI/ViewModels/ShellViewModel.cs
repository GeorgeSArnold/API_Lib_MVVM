﻿using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TicketUI.ViewModels;

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
    }
}