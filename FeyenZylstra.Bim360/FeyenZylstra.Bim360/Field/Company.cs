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
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("company_type")]
        public string CompanyType { get; set; }
        [JsonProperty("company_category")]
        public string CompanyCategory { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}
