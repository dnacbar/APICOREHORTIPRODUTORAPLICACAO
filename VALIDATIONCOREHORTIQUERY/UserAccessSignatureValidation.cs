using APPDTOCOREHORTIQUERY.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTIQUERY
{
    public class UserAccessSignatureValidation : AbstractValidator<UserAccessSignature>
    {
        public UserAccessSignatureValidation()
        {
            RuleFor(x => !string.IsNullOrEmpty(x.DsLogin) && !string.IsNullOrEmpty(x.DsPassword));
        }
    }
}
