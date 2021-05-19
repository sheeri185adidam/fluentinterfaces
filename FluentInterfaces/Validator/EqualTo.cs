using System;

namespace Validator
{
    public class EqualTo<T> : AbstractRule<T> where T: class
    {
        private readonly T _other;

        public EqualTo(T other)
        {
            _other = other;
        }
        protected override bool ValidateInternal(T validating)
        {
            return _other.Equals(validating);
        }
    }
}