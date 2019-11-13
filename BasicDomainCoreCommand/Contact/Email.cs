using DominioCoreBasicoCommand;
using System;

namespace BasicContactDomainCoreCommand
{
    public class Email : Entity
    {
        public string DsEmail { get; set; }
        public bool ValidateEmail() => DsEmail.Contains(@"@") && DsEmail.Contains(@".com") && DsEmail.Length >= 6;
    }
}
