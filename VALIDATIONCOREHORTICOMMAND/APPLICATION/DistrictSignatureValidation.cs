using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateDistrictSignatureValidation : AbstractValidator<DistrictCommandSignature>
    {
        public CreateDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.District).MaximumLength(50);
        }
    }

    public sealed class DeleteDistrictSignatureValidation : AbstractValidator<DistrictCommandSignature>
    {
        public DeleteDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public sealed class UpdateDistrictSignatureValidation : AbstractValidator<DistrictCommandSignature>
    {
        public UpdateDistrictSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.District).MaximumLength(50);
        }
    }
}
