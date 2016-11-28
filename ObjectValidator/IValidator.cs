using System.Collections.Generic;

namespace ObjectValidator
{
    public interface IValidator<in T>
    {
        ValidationResponse IsValid(T entity);

        IEnumerable<string> BrokenRules(T entity);
    }
}