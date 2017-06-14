using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class FieldRequest
    {
        [JsonRequired]
        [JsonProperty("ticket")]
        public Guid Ticket { get; set; }
    }
}
