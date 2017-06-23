using System;
using System.Collections.Generic;
using System.Text;

namespace FeyenZylstra.Bim360.Field
{
    public class PageOptions
    {
        public int Offset { get; set; }
        public int BatchSize { get; set; }
        public int Limit { get; set; }

        public static PageOptions GetDefault()
        {
            return new PageOptions
            {
                Offset = 0,
                BatchSize = 10,
                Limit = 0
            };
        }
    }
}
