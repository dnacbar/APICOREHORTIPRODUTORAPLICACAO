using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class UserCommandSignature
    {
        public bool IsProducer { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } 

        [JsonIgnore]
        public EmailObject Email => new EmailObject(Login);
    }
}
