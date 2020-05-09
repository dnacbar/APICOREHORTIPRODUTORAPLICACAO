using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class ClientConverter
    {
        public static UserClientResult ToUserClientInformationResult(this Client client)
        {
            return new UserClientResult
            {
                IdClient = client.IdClient,
                DsName = client.DsClient,
                DsState = client.IdCityNavigation.Id.DsState,
                DsCity = client.IdCityNavigation.DsCity,
                DsEmail = client.DsEmail,
                DsPhone = client.DsPhone,
                DsDistrict = client.IdDistrictNavigation.DsDistrict
            };
        }
    }
}
