using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;

namespace Sat.Recruitment.Api.UserTypeFactory
{
    public class PremiumUserTypeLogic : IPremiumUserTypeLogic
    {
        public void Resolve(ref User user)
        {
            if (user.Money > 100)
            {
                var gif = user.Money * 2;
                user.Money += gif;
            }
        }
    }
}
