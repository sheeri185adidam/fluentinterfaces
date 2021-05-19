namespace Validator
{
    public abstract class AbstractRule<T> : IRule<T>
    {
        public bool Validate(T validating)
        {
            return ValidateInternal(validating);
        }

        bool IRule.Validate(object validating)
        {
            return Validate((T) validating);
        }

        protected abstract bool ValidateInternal(T validating);
    }
}