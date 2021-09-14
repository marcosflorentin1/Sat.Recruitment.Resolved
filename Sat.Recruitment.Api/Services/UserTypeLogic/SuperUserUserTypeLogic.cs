using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using System;

namespace Sat.Recruitment.Api.UserTypeFactory
{
    public class SuperUserUserTypeLogic : ISuperUserUserTypeLogic
    {
        public void Resolve(ref User user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = user.Money * percentage;
                user.Money += gif;
            }
        }
    }
}
