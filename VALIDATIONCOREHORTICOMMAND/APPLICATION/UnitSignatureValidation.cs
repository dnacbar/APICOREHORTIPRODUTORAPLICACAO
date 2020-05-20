using APPDTOCOREHORTICOMMAND.SIGNATURE;

using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public class CreateUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public CreateUnitSignatureValidation()
        {
            RuleFor(x => x).NotNull().Must(x => !string.IsNullOrEmpty(x.DsUnit));
        }
    }

    public class DeleteUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public DeleteUnitSignatureValidation()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => (int)x.IdUnit).GreaterThan(0);
        }
    }

    public class UpdateUnitSignatureValidation : AbstractValidator<UnitCommandSignature>
    {
        public UpdateUnitSignatureValidation()
        {
            RuleFor(x => x).NotNull().Must(x => !string.IsNullOrEmpty(x.DsUnit));
            RuleFor(x => (int)x.IdUnit).GreaterThan(0);
        }
    }
}
