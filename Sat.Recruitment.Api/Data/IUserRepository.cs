using Sat.Recruitment.Api.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}