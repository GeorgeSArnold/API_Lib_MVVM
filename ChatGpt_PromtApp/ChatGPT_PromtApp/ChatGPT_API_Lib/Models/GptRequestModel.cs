using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API_Lib.Models
{
    public class GptRequestModel
    {
        public string Model { get; set; }
        public List<GptRequestMessageModel> Messages { get; set; }
    }
}
