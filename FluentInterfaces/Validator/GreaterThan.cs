using System;
using System.Collections.Generic;

namespace Validator
{
    public class GreaterThan<T> : AbstractRule<T>
    {
        private T Other { get; }
        private IComparer<T> Comparer { get; }
        
        public GreaterThan(T other)
        {
            Other = other;
            Comparer = Comparer<T>.Default;
        }
        
        public GreaterThan(T other, IComparer<T> comparer)
        {
            Other = other;
            Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        
        protected override bool ValidateInternal(T validating)
        {
            return Comparer.Compare(Other, validating) < 0;
        }
    }
}