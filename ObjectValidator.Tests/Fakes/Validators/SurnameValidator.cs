using System.Collections.Generic;

namespace ObjectValidator.Tests.Fakes.Validators
{
    public class SurnameValidator : IValidator<Person>
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
            if (entity.Surname == "Pippo")
            {
                yield return "You cannot be Pippo";
            }
        }
    }
}