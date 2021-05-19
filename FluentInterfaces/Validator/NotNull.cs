namespace Validator
{
    public class NotNull<T> : AbstractRule<T>
    {
        protected override bool ValidateInternal(T validating)
        {
            return validating != null;
        }
    }
}