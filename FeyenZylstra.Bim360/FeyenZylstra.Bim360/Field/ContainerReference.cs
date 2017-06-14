using System;
using System.Collections.Generic;
using System.Text;

namespace FeyenZylstra.Bim360.Field
{
    public class ContainerReference
    {
        public string FromClass { get; set; }
        public string ToClass { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
    }
}
