using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CoordApp.Model
{
    class JsonData
    {
        [JsonProperty("place_id")]
        public int place_id { get; set; }
        [JsonProperty("licence")]
        public string licence { get; set; }
        [JsonProperty("osm_type")]
        public string osm_type { get; set; }
        [JsonProperty("osm_id")]
        public int osm_id { get; set; }
        [JsonProperty("boundingbox")]
        public IList<string> boundingbox { get; set; }
        [JsonProperty("lat")]
        public string lat { get; set; }
        [JsonProperty("lon")]
        public string lon { get; set; }
        [JsonProperty("display_name")]
        public string display_name { get; set; }

        [JsonProperty("class")]
        public string _class { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("importance")]
        public double importance { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
        [JsonProperty("geojson")]
        public Geojson geojson { get; set; }
    }
}
