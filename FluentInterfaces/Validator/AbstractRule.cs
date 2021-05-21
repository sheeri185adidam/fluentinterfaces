using System.Reflection;

namespace Validator
{
    public abstract class AbstractRule<T> : IRule<T> where T:class
    {
        protected string ObjectName => typeof(T).ToString();
        
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

    public abstract class AbstractRule<T, TProperty> : AbstractRule<T> where T: class
    {
        protected string PropertyName => typeof(TProperty).ToString();
        protected PropertyInfo PropertyInfo => typeof(TProperty).GetProperty(PropertyName);

        protected override bool ValidateInternal(T validating)
        {
            var property = PropertyInfo.GetValue(validating, null);
            return ValidateProperty((TProperty)property);
        }

        protected abstract bool ValidateProperty(TProperty validating);
    }
}