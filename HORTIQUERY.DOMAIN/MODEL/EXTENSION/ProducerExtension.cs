using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class ProducerExtension
    {
        public static IEnumerable<IProducerResult> GetListOfProducerResult(this IEnumerable<Producer> signature)
        {
            var result = new List<IProducerResult>();

            foreach (var item in signature)
                result.Add(new ProducerResult(item));

            return result;
        }
    }
}
