using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace paymentManger
{
    public class SeriesDatas
    {
        [JsonPropertyName("default_Series")]
        public string default_Series{ get; set; }
        [JsonPropertyName("other_Series")]
        public Dictionary<string, string> other_Series { get; set; }


        internal string SeriesName(string id)
        {
            return other_Series[id];
        }
        internal int GetCustomSeriesCount()
        {
            return get_custom_only_dictionary().Count;
        }
        internal string[] GetCustomSeriesNames
        {
            get
            {
                return get_custom_only_dictionary().Values.ToArray();
            }
        }
        internal string[] GetCustomSeriesKeys
        {
            get
            {
                return get_custom_only_dictionary().Keys.ToArray();
            }
        }
        internal string DefaultSeries
        {
            get { return default_Series; }
        }
        private IDictionary<string, string> get_custom_only_dictionary()
        {
            IDictionary<string, string> dic = new Dictionary<string , string>();
            foreach (KeyValuePair<string,string> pair in other_Series)
            {

                if (pair.Key.IndexOf("custom") > -1)
                {
                    dic.Add(pair.Key, pair.Value);
                }
            }
            return dic;
        }
    }
}
