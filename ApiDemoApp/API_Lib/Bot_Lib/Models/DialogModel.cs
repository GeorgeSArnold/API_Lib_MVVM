﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Lib.Models
{
    public class DialogModel
    {
        public string model { get; set; }
        public List<MessageModel> messages { get; set; }
    }
}
