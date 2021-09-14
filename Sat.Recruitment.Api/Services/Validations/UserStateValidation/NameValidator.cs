using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class NameValidator : IValidator<User>, INameValidator
    {
        public List<string> Validate(User user)
        {
            List<string> errors = new List<string>();
            string name = user.Name;

            if (string.IsNullOrEmpty(name))
            {
                errors.Add("The name is required");
            }

            return errors;
        }
    }
}
