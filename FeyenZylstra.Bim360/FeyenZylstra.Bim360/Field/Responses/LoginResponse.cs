using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class LoginResponse
    {
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
