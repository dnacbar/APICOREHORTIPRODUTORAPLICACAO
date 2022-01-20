using FluentValidation;

namespace HORTICOMMAND.APP.VALIDATION.EXTENSION
{
    public static class ExtensionValidator
    {
        public static void ValidateHorti<T>(this IValidator<T> iValidator, T objValidation) where T : class
        {
            ((AbstractValidator<T>)iValidator).CascadeMode = CascadeMode.Stop;

            iValidator.ValidateAndThrow(objValidation);
        }
    }
}
