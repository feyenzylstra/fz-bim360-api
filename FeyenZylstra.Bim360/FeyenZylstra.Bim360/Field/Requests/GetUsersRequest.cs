using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class GetUsersRequest : FieldRequest
    {
        [JsonProperty("project_id")]
        public Guid ProjectId { get; set; }
    }
}
