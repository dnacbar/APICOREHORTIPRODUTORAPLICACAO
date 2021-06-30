using SpanJson;

namespace HORTI.CORE.CROSSCUTTING.EXTENSION
{
    public static class ExtensionJson
    {
        public static string Serialize(this object input)
        {
            return JsonSerializer.Generic.Utf16.Serialize(input);
        }
    }
}
