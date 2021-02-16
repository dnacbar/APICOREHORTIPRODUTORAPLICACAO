using HORTICOMMAND.DOMAIN.MODEL.DOMAINOBJECT;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class UserCommandSignature
    {
        public bool IsProducer { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } 
        public string Phone { get; set; }

        [JsonIgnore]
        public EmailObject Email => new EmailObject(Login);
    }
}
