using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.UserTypeFactory.Contract;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.UserTypeLogic
{
    public class UserTypeLogicCreator : IUserTypeLogicCreator
    {
        public readonly Dictionary<UserType, IUserTypeLogic> instances;

        public UserTypeLogicCreator(
            INormalUserTypeLogic normalUserTypeLogic,
            ISuperUserUserTypeLogic superUserUserTypeLogic,
            IPremiumUserTypeLogic premiumUserTypeLogic
            )
        {
            instances = new Dictionary<UserType, IUserTypeLogic>
            {
                {UserType.Normal, normalUserTypeLogic },
                {UserType.SuperUser, superUserUserTypeLogic },
                {UserType.Premium, premiumUserTypeLogic },
            };
        }

        public IUserTypeLogic GetUserTypeLogicInstance(UserType userType)
        {
            return instances[userType];
        }
    }
}
