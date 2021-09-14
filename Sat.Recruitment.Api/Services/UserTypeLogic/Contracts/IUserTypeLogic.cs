using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.UserTypeFactory.Contract
{
    public interface IUserTypeLogic
    {
        void Resolve(ref User user);
    }
}
