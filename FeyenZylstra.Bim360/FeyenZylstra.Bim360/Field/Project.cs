using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class Project
    {
        [JsonProperty("project_id", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public Guid ProjectId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("default_issue_due_date")]
        public int? DefaultIssueDueDate { get; set; }
        [JsonProperty("issue_workflow_rule")]
        public string IssueWorkflowRule { get; set; }
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
        [JsonProperty("issue_filters")]
        public IEnumerable<IssueFilter> IssueFilters { get; set; }
        [JsonProperty("document_paths")]
        public IEnumerable<DocumentPath> DocumentPaths { get; set; }
        [JsonProperty("permissions")]
        public IEnumerable<ProjectPermission> Permissions { get; set; }
        [JsonProperty("user_roles")]
        public string UserRoles { get; set; }
        [JsonProperty("user_company_id")]
        public string UserCompanyId { get; set; }
        [JsonProperty("lock_closed_checklists")]
        public bool LockClosedChecklists { get; set; }
        [JsonProperty("lock_closed_tasks")]
        public bool LockClosedTasks { get; set; }
        [JsonProperty("task_edit_by_assignee_only")]
        public bool TaskEditByAssigneeOnly { get; set; }
        [JsonProperty("always_allow_attachments")]
        public bool AlwaysAllowAttachments { get; set; }
        [JsonProperty("is_sub")]
        public bool IsSub { get; set; }
        [JsonProperty("is_trial")]
        public bool IsTrial { get; set; }
        [JsonProperty("needs_duns")]
        public bool NeedsDuns { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("brand_color")]
        public string BrandColor { get; set; }
        [JsonProperty("allow_photo_timestamp")]
        public bool AllowPhotoTimestamp { get; set; }
        [JsonProperty("enable_daily_updates")]
        public bool EnableDailyUpdates { get; set; }
        [JsonProperty("issue_id_can_be_changed_by")]
        public string IssueIdCanBeChangedBy { get; set; }
        [JsonProperty("business_unit")]
        public string BusinessUnit { get; set; }
        [JsonProperty("include_in_reports")]
        public bool IncludeInReports { get; set; }
        [JsonProperty("allow_admin_close_any_issue")]
        public bool AllowAdminCloseAnyIssue { get; set; }
        [JsonProperty("daily_update_general_notes_template")]
        public string DailyUpdateGeneralNotesTemplate { get; set; }
        [JsonProperty("new_sub")]
        public bool NewSub { get; set; }
        [JsonProperty("account_company_id")]
        public Guid AccountCompanyId { get; set; }
        
    }
}
