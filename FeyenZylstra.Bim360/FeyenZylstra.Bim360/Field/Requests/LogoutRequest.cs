using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class LogoutRequest
    {
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }
    }
}
