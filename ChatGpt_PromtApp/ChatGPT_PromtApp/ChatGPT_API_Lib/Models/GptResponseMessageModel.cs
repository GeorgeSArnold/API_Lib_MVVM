using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API_Lib.Models
{
    public class GptResponseMessageModel
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
