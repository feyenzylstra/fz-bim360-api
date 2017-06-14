using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class Audit
    {
        [JsonProperty("audit_id")]
        public Guid AuditId { get; set; }
        [JsonProperty("auditable_id")]
        public Guid AuditableId { get; set; }
        [JsonProperty("auditable_type")]
        public string AuditableType { get; set; }
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
        [JsonProperty("user_type")]
        public string UserType { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
