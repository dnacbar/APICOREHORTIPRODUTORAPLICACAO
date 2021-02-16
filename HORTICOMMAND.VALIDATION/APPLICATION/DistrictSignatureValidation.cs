using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace HORTICOMMAND.VALIDATION.APPLICATION
{
    public sealed class CreateDistrictSignatureValidation : AbstractValidator<IDistrictCommandSignature>
    {
        public CreateDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.District).MaximumLength(50);
        }
    }

    public sealed class DeleteDistrictSignatureValidation : AbstractValidator<IDistrictCommandSignature>
    {
        public DeleteDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public sealed class UpdateDistrictSignatureValidation : AbstractValidator<IDistrictCommandSignature>
    {
        public UpdateDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.District).MaximumLength(50);
        }
    }
}
