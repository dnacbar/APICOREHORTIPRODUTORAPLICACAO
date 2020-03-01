using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class ClientConverter
    {
        public static UserClientInformationResult ToUserClientInformationResult(this Client client)
        {
            return new UserClientInformationResult
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
