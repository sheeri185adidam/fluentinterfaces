using System;
using System.Collections.Generic;

namespace Validator
{
    public class EqualTo<T> : AbstractRule<T>
    {
        public EqualTo(T other)
        {
            Other = other;
            Comparer = EqualityComparer<T>.Default;
        }
        
        public EqualTo(T other, IEqualityComparer<T> comparer)
        {
            Other = other;
            Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        protected T Other { get; }

        protected IEqualityComparer<T> Comparer { get; }

        protected override bool ValidateInternal(T validating)
        {
            return Comparer.Equals(validating, Other);
        }
    }
}