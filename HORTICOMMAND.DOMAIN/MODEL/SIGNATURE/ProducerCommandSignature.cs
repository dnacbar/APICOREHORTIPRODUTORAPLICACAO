using HORTICOMMAND.DOMAIN.MODEL.DOMAINOBJECT;
using System;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class ProducerCommandSignature
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Producer { get; set; }
        public string FantasyName { get; set; }
        public int? City { get; set; }
        public Guid? District { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string FederalInscription { get; set; }
        public string StateInscription { get; set; }
        public string MunicipalInscription { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public byte[] ImageByte { get; set; }

        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Email);
        [JsonIgnore]
        public DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
