using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectValidator
{
    public static class Validator
    {
        public static List<IValidator<T>> GetValidatorsFor<T>(T entity) where T : IValidatable<T>
        {
            var type = typeof(IValidator<T>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            return types.Select(t => (IValidator<T>)Activator.CreateInstance(t)).ToList();
        }

        public static ValidationResponse Validate<T>(this T entity) where T : IValidatable<T>
        {
            var validators = GetValidatorsFor(entity);
            var errors = new List<string>();

            foreach (var validator in validators)
            {
                errors.AddRange(entity.Validate(validator).Errors);
            }

            return new ValidationResponse
            {
                Errors = errors
            };
        }
    }
}