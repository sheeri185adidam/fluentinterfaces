using System;
using System.Reflection;

namespace Validator
{
    public abstract class AbstractRule<T> : IRule<T>
    {
        public bool Validate(T validating)
        {
            return ValidateInternal(validating);
        }
        
        protected abstract bool ValidateInternal(T validating);
    }

    public abstract class AbstractRule<T, TProperty> : AbstractRule<T>
    {
        protected string PropertyName { get; }
        protected PropertyInfo PropertyInfo { get; }
        protected AbstractRule(string propertyName)
        {
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            PropertyInfo = typeof(T).GetProperty(PropertyName);
        }
        
        protected override bool ValidateInternal(T validating)
        {
            var property = PropertyInfo.GetValue(validating, null);
            return ValidateProperty((TProperty)property);
        }

        protected abstract bool ValidateProperty(TProperty validating);
    }
}