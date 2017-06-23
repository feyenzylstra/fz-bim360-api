using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FeyenZylstra.Bim360.Field
{
    public class User
    {
        [JsonProperty("id")]
        public Guid UserId { get; set; }
        [JsonProperty("roles")]
        public string Roles { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }
        [JsonProperty("junior")]
        public bool? IsJunior { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        public bool HasRole(string role)
        {
            if (Roles == null) return false;

            return Roles.Split(',').Any(
                x => x.ToLowerInvariant().Trim().Equals(role.ToLowerInvariant().Trim()));
        }
    }
}
