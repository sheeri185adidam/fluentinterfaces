namespace Validator
{
    public class NotNull<T> : AbstractRule<T> where T: class
    {
        protected override bool ValidateInternal(T validating)
        {
            return validating != null;
        }
    }

    public class NotNull<T, TProperty> : AbstractRule<T, TProperty> where T : class
    {
        protected override bool ValidateProperty(TProperty validating)
        {
            return validating != null;
        }
    }
}