using DominioCoreBasicoCommand;
using System;

namespace BasicContactDomainCoreCommand
{
    public class Phone : Entity
    {
        public string DsPhone { get; set; }

        private bool ValidateLength() => DsPhone.Length == 10 || DsPhone.Length == 11 ? true : false;
        private bool ValidateNumber()
        {
            if (!ValidateLength())
                return false;

            foreach (var c in DsPhone)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }
        public bool ValidatePhone() => ValidateNumber() ? true : false;
    }
}
