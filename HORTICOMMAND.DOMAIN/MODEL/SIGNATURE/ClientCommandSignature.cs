using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Runtime.Serialization;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ClientCommandSignature : IClientCommandSignature
    {
        public ClientCommandSignature()
        {
            Id = Id.GetValueOrDefault() == Guid.Empty ? Guid.NewGuid() : Id;
        }

        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Client { get; set; }
        public int? City { get; set; }
        public Guid? District { get; set; }
        public string Phone { get; set; }
        public string FederalInscription { get; set; }
        public byte[] ImageByte { get; set; }

        [IgnoreDataMember]
        public EmailObject EmailObject => new EmailObject(Email);
        [IgnoreDataMember]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [IgnoreDataMember]
        public DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
