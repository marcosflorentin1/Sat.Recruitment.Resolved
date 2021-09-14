using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class EmailValidator : IValidator<User>, IEmailValidator
    {
        public List<string> Validate(User user)
        {
            List<string> errors = new List<string>();
            string email = user.Email;

            if (string.IsNullOrEmpty(email))
            {
                errors.Add("The email is required");
            }

            return errors;
        }
    }
}
