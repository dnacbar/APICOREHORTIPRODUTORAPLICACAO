using System.Linq;

namespace HORTI.CORE.CROSSCUTTING.EXTENSION
{
    public static class ExtensionString
    {
        public static bool IsOnlyNumber(this string strValue)
        {
            return int.TryParse(strValue, out _);
        }

        public static bool IsOnlyText(this string strValue)
        {
            return strValue.All(char.IsLetter);
        }

        public static bool IsOnlyTextAndNumber(this string strValue)
        {
            return strValue.All(char.IsLetterOrDigit);
        }

        public static string RemoveSpecialCharacter(this string strValue)
        {
            var strResult = string.Empty;

            foreach (var item in strValue)
            {
                if (char.IsNumber(item) || char.IsLetter(item))
                    strResult += item;
            }

            return strResult;
        }
    }
}
