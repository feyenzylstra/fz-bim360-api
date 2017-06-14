using System;
using System.Collections.Generic;
using System.Text;

namespace FeyenZylstra.Bim360.Field
{
    public class FieldApiException : Exception
    {
        public FieldApiException(string message)
            : base(message) { }

        public FieldApiException(string message, Exception ex)
            : base(message, ex) { }
    }
}
