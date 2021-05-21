using System;
using System.Collections.Generic;

namespace Validator
{
    public class LessThan<T> : AbstractRule<T>
    {
        private T Other { get; }
        private IComparer<T> Comparer { get; }
        
        public LessThan(T other)
        {
            Other = other;
            Comparer = Comparer<T>.Default;
        }
        
        public LessThan(T other, IComparer<T> comparer)
        {
            Other = other;
            Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        
        protected override bool ValidateInternal(T validating)
        {
            return Comparer.Compare(Other, validating) > 0;
        }
    }
}