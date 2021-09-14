using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class AddressValidator : IValidator<User>, IAddressValidator
    {
        public List<string> Validate(User user)
        {
            List<string> errors = new List<string>();
            string address = user.Address;

            if (string.IsNullOrEmpty(address))
            {
                errors.Add("The address is required");
            }

            return errors;
        }
    }
}
