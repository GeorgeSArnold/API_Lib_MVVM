using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API_Lib.Models
{
    public class GptResponseModel
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public List<GptChoiceModel> Choices { get; set; }
        public GptUsageModel Usage { get; set; }
    }
}
