using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL.DOMAINOBJECT;
using System.Text.Json.Serialization;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserCommandSignature : IUserCommandSignature
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
