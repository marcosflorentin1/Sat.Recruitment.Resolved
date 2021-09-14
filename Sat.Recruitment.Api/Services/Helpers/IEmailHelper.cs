using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Services.Helpers
{
    public interface IEmailHelper
    {
        void NormalizeUserEmail(ref User user);
    }
}