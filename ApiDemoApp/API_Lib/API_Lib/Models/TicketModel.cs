using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Lib.Models
{
    public class TicketModel
    {
        // table props
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Created_at { get; set; }
        // backend props
        //public int[] Article_ids { get; set; }
    }
}
