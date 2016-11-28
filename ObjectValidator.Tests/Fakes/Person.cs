namespace ObjectValidator.Tests.Fakes
{
    public class Person : IValidatable<Person>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public ValidationResponse Validate(IValidator<Person> validator)
        {
            return validator.IsValid(this);
        }
    }
}