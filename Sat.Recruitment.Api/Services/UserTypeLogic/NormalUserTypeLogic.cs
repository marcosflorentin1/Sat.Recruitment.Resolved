using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using System;

namespace Sat.Recruitment.Api.UserTypeFactory
{
    public class NormalUserTypeLogic : INormalUserTypeLogic
    {
        public void Resolve(ref User user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = user.Money * percentage;
                user.Money = user.Money + gif;
            }
            if (user.Money < 100)
            {
                if (user.Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = user.Money * percentage;
                    user.Money += gif;
                }
            }
        }
    }
}
