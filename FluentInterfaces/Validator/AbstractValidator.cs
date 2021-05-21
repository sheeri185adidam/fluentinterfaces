using System.Linq;

namespace Validator
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {
        protected RuleBuilder<T> RuleBuilder { get; } = RuleBuilder<T>.Instance;

        public virtual bool Validate(T validating)
        {
            return RuleBuilder.Rules.All(rule => rule.Validate(validating));
        }
    }
}