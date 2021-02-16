using HORTIQUERY.DOMAIN.MODEL.RESULT;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTER
{
    public static class ClientConverter
    {
        public static HashSet<ClientResult> ToHashSetClientResult(this IEnumerable<IClient> lstClient)
        {
            var result = new HashSet<ClientResult>();

            foreach (var item in lstClient)
            {
                result.Add(new ClientResult
                {
                    IdCity = item.IdCity,
                    IdDistrict = item.IdDistrict,
                    DsEmail = item.DsEmail,
                    DsName = item.DsClient,
                    DsPhone = item.DsPhone,
                    IdState = item.IdCityNavigation.IdState
                });
            }

            return result;
        }
        public static ClientResult ToClientResult(this IClient client)
        {
            return new ClientResult
            {
                IdClient = client.IdClient,
                DsName = client.DsClient,
                IdState = client.IdCityNavigation.IdState,
                IdCity = client.IdCity,
                DsEmail = client.DsEmail,
                DsPhone = client.DsPhone,
                IdDistrict = client.IdDistrict
            };
        }
    }
}
