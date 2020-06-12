using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class ClientCommandSignature
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Client { get; set; }
        public int? City { get; set; }
        public Guid? District { get; set; }
        public string Phone { get; set; }
        public string FederalInscription { get; set; }
        

        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Email);

        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);

        [JsonIgnore]
        public DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
