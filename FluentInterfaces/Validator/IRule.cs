namespace Validator
{
    public interface IRule<in T>
    {
        bool Validate(T validating);
    }
}