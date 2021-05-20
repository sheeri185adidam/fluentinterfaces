using System.Collections.Generic;

namespace Validator
{
    public class RuleBuilder<T> where T: class
    {
        private readonly IList<IRule> _rules = new List<IRule>();
        public IEnumerable<IRule> Rules => _rules;

        public static RuleBuilder<T> Instance => new RuleBuilder<T>();
        
        public RuleBuilder<T> IsNotNull()
        {
            _rules.Add(new NotNull<T>());
            return this;
        }

        public RuleBuilder<T> IsEqualsTo(T other)
        {
            _rules.Add(new EqualTo<T>(other));
            return this;
        }
    }
}