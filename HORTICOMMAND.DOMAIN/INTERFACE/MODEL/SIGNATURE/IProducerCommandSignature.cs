﻿using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using System;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IProducerCommandSignature
    {
        Guid? Id { get; set; }
        string Email { get; set; }
        string Producer { get; set; }
        string FantasyName { get; set; }
        int? City { get; set; }
        Guid? District { get; set; }
        string Zip { get; set; }
        string Address { get; set; }
        string Number { get; set; }
        string Complement { get; set; }
        string FederalInscription { get; set; }
        string StateInscription { get; set; }
        string MunicipalInscription { get; set; }
        string Description { get; set; }
        string Phone { get; set; }
        byte[] ImageByte { get; set; }

        EmailObject EmailObject => new EmailObject(Email);
        PhoneObject PhoneObject => new PhoneObject(Phone);
        DocumentObject FederalDocument => new DocumentObject(FederalInscription);
    }
}
