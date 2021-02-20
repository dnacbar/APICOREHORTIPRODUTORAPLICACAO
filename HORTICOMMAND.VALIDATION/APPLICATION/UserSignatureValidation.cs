using FluentValidation;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.VALIDATION.APPLICATION
{
    public sealed class CreateUserSignatureValidation : AbstractValidator<IUserCommandSignature>
    {
        private readonly IUserAccessRepository _userAccessRepository;

        public CreateUserSignatureValidation(IUserAccessRepository userAccessRepository)
        {
            _userAccessRepository = userAccessRepository;

            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(100).Must(x => ValidatePassword(x));
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x).MustAsync(async (x, y) => await ValidateUserNotExists(x)).WithMessage("USER ALREADY EXISTS!");
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

        private async Task<bool> ValidateUserNotExists(IUserCommandSignature signature)
        {
            return (await _userAccessRepository.GetUserHortiAccess(new UserAccessQuerySignature { Login = signature.Login })) == null;
        }
    }

    public sealed class DeleteUserSignatureValidation : AbstractValidator<IUserCommandSignature>
    {
        private readonly IUserAccessRepository _userAccessRepository;
        public DeleteUserSignatureValidation(IUserAccessRepository userAccessRepository)
        {
            _userAccessRepository = userAccessRepository;

            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x).MustAsync(async (x, y) => await ValidateUserExists(x)).WithMessage("USER NOT EXISTS!");
        }

        private async Task<bool> ValidateUserExists(IUserCommandSignature signature)
        {
            return (await _userAccessRepository.GetUserHortiAccess(new UserAccessQuerySignature { Login = signature.Login })) != null;
        }
    }

    public sealed class UpdateUserSignatureValidation : AbstractValidator<IUserCommandSignature>
    {
        private readonly IUserAccessRepository _userAccessRepository;
        public UpdateUserSignatureValidation(IUserAccessRepository userAccessRepository)
        {
            _userAccessRepository = userAccessRepository;
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(100).Must(x => ValidatePassword(x));
            RuleFor(x => x).MustAsync(async (x, y) => await ValidateUserExists(x)).WithMessage("USER NOT EXISTS!");
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

        private async Task<bool> ValidateUserExists(IUserCommandSignature signature)
        {
            return (await _userAccessRepository.GetUserHortiAccess(new UserAccessQuerySignature { Login = signature.Login })) != null;
        }
    }
}
