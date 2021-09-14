using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Validations.UserStateValidation
{
    public class UserValidator : IUserValidator
    {
        private readonly IValidator<User> _nameValidator;
        private readonly IValidator<User> _emailValidator;
        private readonly IValidator<User> _addressValidator;
        private readonly IValidator<User> _phoneValidator;
        private readonly ICompositeValidator<User> _compositeValidator;

        public UserValidator(
            INameValidator nameValidator,
            IEmailValidator emailValidator,
            IAddressValidator addressValidator,
            IPhoneValidator phoneValidator
            )
        {
            _nameValidator = (IValidator<User>)nameValidator;
            _emailValidator = (IValidator<User>)emailValidator;
            _addressValidator = (IValidator<User>)addressValidator;
            _phoneValidator = (IValidator<User>)phoneValidator;

            var validators = new List<IValidator<User>>
            {
                _nameValidator,
                _emailValidator,
                _addressValidator,
                _phoneValidator
            };

            _compositeValidator = new CompositeValidator<User>(validators);
        }

        public List<string> Validate(User user)
        {
            return _compositeValidator.Validate(user);
        }
    }
}
