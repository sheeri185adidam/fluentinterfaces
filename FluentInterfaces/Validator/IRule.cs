namespace Validator
{
    public interface IRule
    {
        bool Validate(object validating);
    }
    
    public interface IRule<in T> : IRule
    {
        bool Validate(T validating);
    }
}