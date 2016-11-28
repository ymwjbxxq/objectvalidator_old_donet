using System.Collections.Generic;

namespace ObjectValidator.Tests.Fakes.Validators
{
    public class NameValidator : IValidator<Person>
    {
        public ValidationResponse IsValid(Person entity)
        {
            return new ValidationResponse
            {
                Errors = BrokenRules(entity)
            };
        }

        public IEnumerable<string> BrokenRules(Person entity)
        {
            if (entity.Name == "Pluto")
            {
                yield return "You cannot be Pluto";
            }
        }
    }
}