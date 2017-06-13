using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPlaces.Models
{
    public class Response
    {
        [JsonProperty("results")]
        public List<Place> Places { get; set; }
        [JsonProperty("status")]
        public string Message { get; set; }
        public bool IsSuccess { get { return Message.ToLower().Equals("ok"); } }
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }
    }
}
