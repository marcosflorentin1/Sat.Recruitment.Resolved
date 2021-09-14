using Sat.Recruitment.Api.Models;
using System;

namespace Sat.Recruitment.Api.Services.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public void NormalizeUserEmail(ref User user)
        {
            //Normalize email
            var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            user.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
