using System;
using System.Collections.Generic;
using System.Text;

namespace MyBot.Assets
{
    class Command
    {
        public string name { get; set; }
        public List<string> alias { get; set; }
        public string description { get; set; }
    }
}
