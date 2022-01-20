using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class ClientResult : UserResult, IClientResult
    {
        public ClientResult(Client client)
        {
            Id = client.IdClient;
            Name = client.DsClient;
            Email = client.DsEmail;
            IdCity = client.IdCity;
            IdDistrict = client.IdDistrict;
            IdState = client.IdCityNavigation.IdState;
            Phone = client.DsPhone;
            Address = client.DsAddress;
            Number = client.DsNumber;
            Complement = client.DsComplement;
            Zip = client.DsZip;
        }

        public Guid Id { get; set; }
    }
}
