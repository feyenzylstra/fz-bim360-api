using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class CustomFieldValue
    {
        [JsonProperty("custom_field_value_id")]
        public Guid CustomFieldValueId { get; set; }
        [JsonProperty("custom_field_definition_id")]
        public Guid CustomFieldDefinitionId { get; set; }
        [JsonProperty("container_id")]
        public Guid ContainerId { get; set; }
        [JsonProperty("container_type")]
        public string ContainerType { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
