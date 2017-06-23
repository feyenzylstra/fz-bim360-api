using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class GetTasksRequest : FieldRequest
    {
        [JsonRequired]
        [JsonProperty("project_id")]
        public Guid ProjectId { get; set; }
        [JsonProperty("max_date")]
        public string MaxDate { get; set; }
        [JsonProperty("filter_id")]
        public Guid? FilterId { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
