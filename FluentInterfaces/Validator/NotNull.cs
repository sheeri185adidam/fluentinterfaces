namespace Validator
{
    public class NotNull<T> : AbstractRule<T>
    {
        protected override bool ValidateInternal(T validating)
        {
            return validating != null;
        }
    }

    public class NotNull<T, TProperty> : AbstractRule<T, TProperty>
    {
        public NotNull(string propertyName) : base(propertyName)
        {
        }
        
        protected override bool ValidateProperty(TProperty validating)
        {
            return validating != null;
        }
    }
}