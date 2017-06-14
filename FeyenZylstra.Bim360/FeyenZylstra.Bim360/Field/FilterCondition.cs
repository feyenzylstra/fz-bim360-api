using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class FilterCondition
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        [JsonProperty("operation")]
        public string Operation { get; set; }
        [JsonProperty("values")]
        public IEnumerable<string> Values { get; set; }
        [JsonProperty("sort_field")]
        public bool SortField { get; set; }
        [JsonProperty("sort_direction")]
        public string SortDirection { get; set; }
    }
}
