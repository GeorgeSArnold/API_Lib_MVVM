using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API_Lib.Models
{
    public class GptChoiceModel
    {
        public int Index { get; set; }
        public GptResponseMessageModel Message { get; set; }
        public string FinishReason { get; set; }
    }
}
