using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ClientExtension
    {
        public static IClientResult GetClientResult(this Client signature)
        {
            return new ClientResult
            {
                Id = signature.IdClient,
                Name = signature.DsClient,
                Email = signature.DsEmail,
                Phone = signature.DsPhone,
                IdCity = signature.IdCity,
                IdState = signature.IdCityNavigation.IdState,
                IdDistrict = signature.IdDistrict,
                Address = signature.DsAddress,
                Complement = signature.DsComplement,
                Number = signature.DsNumber,
                Zip = signature.DsZip
            };
        }

        public static IEnumerable<IClientResult> GetListOfClientResult(this IEnumerable<Client> signature)
        {
            var result = new List<IClientResult>();
            foreach (var item in signature)
            {
                result.Add(new ClientResult
                {
                    Id = item.IdClient,
                    Name = item.DsClient,
                    Email = item.DsEmail,
                    Phone = item.DsPhone,
                    IdCity = item.IdCity,
                    IdState = item.IdCityNavigation.IdState,
                    IdDistrict = item.IdDistrict,
                    
                });
            }
            return result;
        }
    }
}
