using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Lib.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Created_at { get; set; }
        public string Body { get; set; }
    }
}
