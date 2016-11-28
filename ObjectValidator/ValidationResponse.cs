using System.Collections.Generic;
using System.Linq;

namespace ObjectValidator
{
    public class ValidationResponse
    {
        public virtual bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public virtual IEnumerable<string> Errors { get; set; }
    }
}