using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class CompositeValidator<T> : ICompositeValidator<T>
    {

        private List<IValidator<T>> _validators;

        public CompositeValidator(List<IValidator<T>> validators)
        {
            this._validators = validators;
        }

        public List<string> Validate(T info)
        {
            List<string> errors = new List<string>();
            IEnumerable<string> validations;

            foreach (var validator in _validators)
            {
                validations = validator.Validate(info);

                errors.AddRange(validations);
            }

            return errors;
        }
    }
}
