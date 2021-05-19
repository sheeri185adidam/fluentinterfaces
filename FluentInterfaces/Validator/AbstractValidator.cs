namespace Validator
{
    public abstract class AbstractValidator<T> : IValidator<T> where T:class
    {
        protected RuleBuilder<T> RuleBuilder { get; set; } = RuleBuilder<T>.Instance;

        public virtual bool Validate(T validating)
        {
            foreach (var rule in RuleBuilder.Rules)
            {
                if (!rule.Validate(validating))
                {
                    return false;
                }
            }

            return true;
        }
    }
}