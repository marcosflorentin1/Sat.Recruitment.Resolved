using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.UserTypeFactory.Contract;

namespace Sat.Recruitment.Api.UserTypeLogic.Contracts
{
    public interface IUserTypeLogicCreator
    {
        IUserTypeLogic GetUserTypeLogicInstance(UserType userType);
    }
}