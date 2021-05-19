namespace Validator
{
    public interface IValidator<in T>
    {
        bool Validate(T validating);
    }
}