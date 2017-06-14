using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class ProjectTask
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("project_id")]
        public Guid ProjectId { get; set; }
        [JsonProperty("template")]
        public bool IsTemplate { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }
        [JsonProperty("assigned_user_id")]
        public Guid AssignedUserId { get; set; }
        [JsonProperty("created_user_id")]
        public Guid CreatedUserId { get; set; }
        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }
        [JsonProperty("task_types")]
        public IEnumerable<ContainerReference> TaskTypes { get; set; }
        [JsonProperty("location_detail")]
        public string LocationDetail { get; set; }
        [JsonProperty("send_reminders")]
        public bool SendReminders { get; set; }
        [JsonProperty("header")]
        public string Header { get; set; }
        [JsonProperty("footer")]
        public string Footer { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("assigned_to_me")]
        public bool IsAssignedToMe { get; set; }
        [JsonProperty("created_by_me")]
        public bool IsCreatedByMe { get; set; }
        [JsonProperty("created_company_id")]
        public Guid CreatedCompanyId { get; set; }
        [JsonProperty("custom_field_values")]
        public IEnumerable<CustomFieldValue> CustomFieldValues { get; set; }
        [JsonProperty("audits")]
        public IEnumerable<Audit> Audits { get; set; }
        [JsonProperty("equipment")]
        public IEnumerable<ContainerReference> Equipment { get; set; }
    }
}
