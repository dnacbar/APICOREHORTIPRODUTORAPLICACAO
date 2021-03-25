using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Text.Json.Serialization;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ClientCommandSignature : IClientCommandSignature
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Client { get; set; }
        public int? City { get; set; }
        public Guid? District { get; set; }
        public string Phone { get; set; }
        public string FederalInscription { get; set; }
        public byte[] ImageByte { get; set; }

        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Email);
        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [JsonIgnore]
        public DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
