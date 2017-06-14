using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class ProjectPermission
    {
        [JsonProperty("realm")]
        public string Realm { get; set; }
        [JsonProperty("permission")]
        public string Permission { get; set; }
    }
}
