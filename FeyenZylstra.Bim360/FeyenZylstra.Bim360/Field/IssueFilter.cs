using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class IssueFilter
    {
        [JsonProperty("issue_filter_id")]
        public Guid IssueFilterId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
