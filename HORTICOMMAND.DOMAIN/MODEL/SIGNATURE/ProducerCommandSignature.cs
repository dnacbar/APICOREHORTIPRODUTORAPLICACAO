using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Runtime.Serialization;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ProducerCommandSignature : IProducerCommandSignature
    {
        public ProducerCommandSignature()
        {
            Id = Id.GetValueOrDefault() == Guid.Empty ? Guid.NewGuid() : Id;
        }

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

        [IgnoreDataMember]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [IgnoreDataMember]
        public EmailObject EmailObject => new EmailObject(Email);
        [IgnoreDataMember]
        public DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
