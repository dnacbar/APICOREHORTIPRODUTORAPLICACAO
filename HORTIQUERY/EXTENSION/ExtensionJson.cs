using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using SpanJson;
using System.Collections.Generic;

namespace HORTIQUERY.EXTENSION
{
    public static class ExtensionJson
    {
        public static string Serialize(this IResult result)
        {
            return JsonSerializer.Generic.Utf16.Serialize(result);
        }

        public static string Serialize(this IEnumerable<IResult> result)
        {
            return JsonSerializer.Generic.Utf16.Serialize(result);
        }
    }
}
