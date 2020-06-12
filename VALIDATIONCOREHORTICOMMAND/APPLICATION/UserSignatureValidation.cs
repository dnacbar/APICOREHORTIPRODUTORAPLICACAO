using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateUserSignatureValidation : AbstractValidator<UserCommandSignature>
    {
        public CreateUserSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(100).Must(x => ValidatePassword(x));
            RuleFor(x => x.UserName).NotEmpty();
        }

        private bool ValidatePassword(string strPassword)
        {
            var haveNumber = false;
            var haveLetter = false;
            var haveUpper = false;
            var haveSpecial = false;

            foreach (var item in strPassword)
            {
                if (char.IsWhiteSpace(item))
                    return false;

                if (haveNumber && haveLetter && haveUpper && haveSpecial)
                    return true;

                if (char.IsUpper(item))
                {
                    haveUpper = true;
                    continue;
                }
                if (char.IsNumber(item))
                {
                    haveNumber = true;
                    continue;
                }
                if (char.IsLetter(item))
                {
                    haveLetter = true;
                    continue;
                }
                if (char.IsSymbol(item) || char.IsPunctuation(item))
                {
                    haveSpecial = true;
                    continue;
                }

            }
            return false;
        }
    }

    public sealed class DeleteUserSignatureValidation : AbstractValidator<UserCommandSignature>
    {
        public DeleteUserSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
        }
    }

    public sealed class UpdateUserSignatureValidation : AbstractValidator<UserCommandSignature>
    {
        public UpdateUserSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(100).Must(x => ValidatePassword(x));
        }

        private bool ValidatePassword(string strPassword)
        {
            var haveNumber = false;
            var haveLetter = false;
            var haveUpper = false;
            var haveSpecial = false;

            foreach (var item in strPassword)
            {
                if (char.IsWhiteSpace(item))
                    return false;

                if (haveNumber && haveLetter && haveUpper && haveSpecial)
                    return true;

                if (char.IsUpper(item))
                {
                    haveUpper = true;
                    continue;
                }
                if (char.IsNumber(item))
                {
                    haveNumber = true;
                    continue;
                }
                if (char.IsLetter(item))
                {
                    haveLetter = true;
                    continue;
                }
                if (char.IsSymbol(item) || char.IsPunctuation(item))
                {
                    haveSpecial = true;
                    continue;
                }

            }
            return false;
        }
    }
}
