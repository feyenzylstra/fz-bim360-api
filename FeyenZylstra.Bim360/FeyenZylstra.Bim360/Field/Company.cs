using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class Company
    {
        [JsonProperty("id")]
        public Guid CompanyId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
