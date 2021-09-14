using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation.Contracts
{
    public interface IValidator<T>
    {
        List<string> Validate(T info);
    }
}
