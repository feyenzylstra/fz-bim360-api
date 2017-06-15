using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class GetAdminFiltersRequest : FieldRequest
    {
        [JsonProperty("project_id")]
        public Guid ProjectId { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
