using System.Collections.Generic;

namespace Validator
{
    public class NotEqualTo<T> : EqualTo<T>
    {
        public NotEqualTo(T other) : base(other)
        {
        }

        public NotEqualTo(T other, IEqualityComparer<T> comparer) : base(other, comparer)
        {
        }

        protected override bool ValidateInternal(T validating)
        {
            return !base.ValidateInternal(validating);
        }
    }
}