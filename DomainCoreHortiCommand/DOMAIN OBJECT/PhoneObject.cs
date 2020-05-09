using CROSSCUTTINGCOREHORTI.EXTENSION;

namespace DOMAINCOREHORTICOMMAND.DOMAIN_OBJECT
{
    public sealed class PhoneObject
    {
        public PhoneObject(string phoneObject, string cultureName)
        {
            Phone = phoneObject;
            CultureName = cultureName;
            ValidatePhone();
        }

        private string CultureName { get; set; }
        public string Phone { get; private set; }
        public bool IsCellPhone => Phone.Length == 11;

        private void ValidatePhone()
        {
            if (CultureName.Equals("pt-Br"))
                ValidateBrazilianPhone();
        }

        private void ValidateBrazilianPhone()
        {
            if (Phone.Length != 11 || Phone.Length != 10)
                Phone = null;

            if (!Phone.IsOnlyNumber())
                Phone = null;
        }
    }
}
