using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Service
{
    public interface IUserService
    {
        Result Create(User user);
    }
}