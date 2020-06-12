using CROSSCUTTINGCOREHORTI.ENUM;
using CROSSCUTTINGCOREHORTI.EXTENSION;

namespace DOMAINCOREHORTICOMMAND.DOMAINOBJECT
{
    public sealed class PhoneObject
    {
        public PhoneObject(string phoneObject, EnumCultureInfo cultureInfo = EnumCultureInfo.Brazilian)
        {
            Phone = phoneObject;
            CultureInfo = cultureInfo;
        }

        public string Phone { get; private set; }
        public bool IsCellPhone => VerifyCellPhone();

        public bool IsValid()
        {
            if (CultureInfo == EnumCultureInfo.Brazilian)
                return ValidateBrazilianPhone();

            return false;
        }

        private EnumCultureInfo CultureInfo { get; set; }

        private bool ValidateBrazilianPhone()
        {
            if (Phone.Length != 11 || Phone.Length != 10)
                return false;

            if (!Phone.IsOnlyNumber())
                return false;

            return true;
        }

        private bool VerifyCellPhone()
        {
            if (CultureInfo == EnumCultureInfo.Brazilian)
                return Phone.Length == 11;

            return false;
        }
    }
}
