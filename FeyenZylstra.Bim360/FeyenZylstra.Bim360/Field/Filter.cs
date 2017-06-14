using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class Filter
    {
        [JsonProperty("filter_id")]
        public Guid FilterId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("container")]
        public string Container { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("conditions")]
        public IEnumerable<FilterCondition> Conditions { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("updated_by")]
        public string UpdatedBy { get; set; }
        [JsonProperty("roles")]
        public string Roles { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
