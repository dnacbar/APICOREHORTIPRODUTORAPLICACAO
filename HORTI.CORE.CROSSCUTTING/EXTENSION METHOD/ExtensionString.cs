namespace HORTI.CORE.CROSSCUTTING.EXTENSION
{
    public static class ExtensionString
    {
        public static bool IsOnlyNumber(this string strValue)
        {
            int i = 0;
            return int.TryParse(strValue, out i);
        }

        public static bool IsOnlyText(this string strValue)
        {
            foreach (var item in strValue)
            {
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }

        public static bool IsOnlyTextAndNumber(this string strValue)
        {
            foreach (var item in strValue)
            {
                if (!char.IsLetterOrDigit(item))
                    return false;
            }
            return true;
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
