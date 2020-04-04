using System;
using System.Collections.Generic;
using System.Text;

namespace DevToReader
{
    public class DevToResponse
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string tags { get; set; }
        public DateTime published_timestamp { get; set; }
    }
}
