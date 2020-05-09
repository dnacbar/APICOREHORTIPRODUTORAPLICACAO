namespace CROSSCUTTINGCOREHORTI.EXTENSION
{
    public static class StringExtension
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
        
        public static bool IsOnlyTextNumber(this string strValue)
        {
            foreach (var item in strValue)
            {
                if (!char.IsLetterOrDigit(item))
                    return false;
            }
            return true;
        }
    }
}
