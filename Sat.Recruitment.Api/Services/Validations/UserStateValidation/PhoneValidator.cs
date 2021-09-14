using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class PhoneValidator : IValidator<User>, IPhoneValidator
    {
        public List<string> Validate(User user)
        {
            List<string> errors = new List<string>();
            string phone = user.Phone;

            if (string.IsNullOrEmpty(phone))
            {
                errors.Add("The phone is required");
            }

            return errors;
        }
    }
}
