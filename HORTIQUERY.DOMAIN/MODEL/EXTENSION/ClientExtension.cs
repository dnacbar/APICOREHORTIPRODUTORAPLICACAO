using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ClientExtension
    {
        public static IEnumerable<IClientResult> GetListOfClientResult(this IEnumerable<Client> signature)
        {
            var result = new List<IClientResult>();

            foreach (var item in signature)
                result.Add(new ClientResult(item));

            return result;
        }
    }
}
