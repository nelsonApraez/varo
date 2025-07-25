namespace Varo.Maestros.Entidades
{
    using Newtonsoft.Json;

    public class Usuario
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("givenName")]
        public string GivenName { get; set; }
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        [JsonProperty("mail")]
        public string Mail { get; set; }
        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }
        [JsonProperty("officeLocation")]
        public string OfficeLocation { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }
    }
}

