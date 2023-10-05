﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Lib.Models
{
    public class TicketModel : INotifyPropertyChanged
    {
        // props
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Created_at { get; set; }

        // article ids = (list<int>) > strings
        private List<int> _articleIds;
        public List<int> Article_ids
        {
            get { return _articleIds; }
            set
            {
                _articleIds = value;
                OnPropertyChanged(nameof(Article_ids));
                UpdateArticleIdsString();
            }
        }

        // backend props
        private string _articleIdsString;
        public string ArticleIdsString
        {
            get { return _articleIdsString; }
            set
            {
                _articleIdsString = value;
                OnPropertyChanged(nameof(ArticleIdsString));
            }
        }

        // const
        public TicketModel()
        {
            Article_ids = new List<int>();
            UpdateArticleIdsString();
        }

        // methods
        private void UpdateArticleIdsString()
        {
            ArticleIdsString = string.Join(", ", Article_ids);
        }

        // event handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
