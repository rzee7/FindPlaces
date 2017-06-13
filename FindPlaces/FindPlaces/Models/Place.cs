using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPlaces.Models
{
    public class Place
    {
        [JsonProperty("formatted_address")]
        public string Address { get; set; }
        [JsonProperty("icon")]
        public string PlaceIcon { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("place_id")]
        public string PlaceID { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("types")]
        public List<string> PlaceTypes { get; set; }
    }
}
