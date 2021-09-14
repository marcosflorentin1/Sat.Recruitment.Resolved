using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class UserDuplicateValidator : IUserDuplicateValidator
    {
        public bool IsDuplicateUser(User user, IEnumerable<User> savedUsers)
        {
            if (savedUsers.Any(su =>
                    (su.Email == user.Email || su.Phone == user.Phone) ||
                    (su.Name == user.Name && su.Address == user.Address))
                )
            {
                Debug.WriteLine("The user is duplicated");

                return true;
            }

            return false;
        }
    }
}
