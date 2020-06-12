using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public CreateUnitSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Unit).NotEmpty();   
        }
    }

    public sealed class DeleteUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public DeleteUnitSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => (int)x.Id).GreaterThan(0);
        }
    }

    public sealed class UpdateUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public UpdateUnitSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Unit).NotEmpty();
            RuleFor(x => (int)x.Id).GreaterThan(0);
        }
    }
}
