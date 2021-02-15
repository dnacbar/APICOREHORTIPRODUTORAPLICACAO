using FluentValidation;

namespace CROSSCUTTINGCOREHORTI.EXTENSION
{
    public static class ExtensionValidation
    {
        public static void ValidateHorti<T>(this IValidator<T> iValidator, T objValidation) where T : class
        {
            iValidator.CascadeMode = CascadeMode.StopOnFirstFailure;

            iValidator.ValidateAndThrow(objValidation);
        }
    }
}
