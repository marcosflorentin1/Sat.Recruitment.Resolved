using Sat.Recruitment.Api.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation.Contracts
{
    public interface IUserDuplicateValidator
    {
        bool IsDuplicateUser(User user, IEnumerable<User> savedUsers);
    }
}
