using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace paymentManger
{
    public class SeriesClassificationData
    {
        [JsonPropertyName("based_series")]
        public List<string> bases_series { get; set; }
        [JsonPropertyName("op")]
        public string op { get; set; }
        [JsonPropertyName("com_value")]
        public List<string> com_value { get; set; }
    }
}
