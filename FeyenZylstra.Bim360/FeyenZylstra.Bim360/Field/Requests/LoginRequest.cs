using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    internal class LoginRequest
    {
        [JsonRequired]
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("device_identifier")]
        public string DeviceIdentifier { get; set; }
    }
}
