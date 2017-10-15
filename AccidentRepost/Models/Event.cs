using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccidentRepost.Models
{
    public partial class Event
    {
        public int id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string video_url { get; set; }
        public string date { get; set; }
        public Nullable<bool> important { get; set; }
    }
}