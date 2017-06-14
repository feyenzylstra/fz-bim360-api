using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class DocumentPath
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("dir_size")]
        public int DirectorySize { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("folder_id", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public Guid FolderId { get; set; }
        [JsonProperty("parent_folder_id")]
        public Guid ParentFolderId { get; set; }
    }
}
