namespace ObjectValidator
{
    public interface IValidatable<out T>
    {
        ValidationResponse Validate(IValidator<T> validator);
    }
}