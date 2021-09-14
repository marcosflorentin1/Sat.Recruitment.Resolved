using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services.Helpers;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Api.Service
{
    public class UserService : IUserService
    {
        private readonly IUserValidator _userValidator;
        private readonly IUserTypeLogicCreator _userTypeLogicCreator;
        private readonly IUserRepository _userRepository;
        private readonly IUserDuplicateValidator _userDuplicateValidator;
        private readonly IEmailHelper _emailHelper;

        public UserService(
            IUserValidator userValidator,
            IUserTypeLogicCreator userTypeLogicCreator,
            IUserRepository userRepository,
            IUserDuplicateValidator userDuplicateValidator,
            IEmailHelper emailHelper
            )
        {
            _userValidator = userValidator;
            _userTypeLogicCreator = userTypeLogicCreator;
            _userRepository = userRepository;
            _userDuplicateValidator = userDuplicateValidator;
            _emailHelper = emailHelper;
        }

        public Result Create(User user)
        {
            var userCreationResult = new Result();
            List<string> errors = _userValidator.Validate(user);

            // Validating the model
            if (errors.Any())
            {
                userCreationResult.IsSuccess = false;
                userCreationResult.Errors = String.Join(" ", errors.ToArray());

                return userCreationResult;
            }

            // Resolving userType logic & normalizing email
            var newUserType = Enum.Parse<UserType>(user.UserType);
            var userTypeLogic = _userTypeLogicCreator.GetUserTypeLogicInstance(newUserType);
            userTypeLogic.Resolve(ref user);
            _emailHelper.NormalizeUserEmail(ref user);

            // Checking for duplicates
            var savedUsers = _userRepository.GetAllUsers();
            var isUserDuplicated = _userDuplicateValidator.IsDuplicateUser(user, savedUsers);
            if (isUserDuplicated)
            {
                userCreationResult.IsSuccess = false;
                userCreationResult.Errors = "The user is duplicated";

                return userCreationResult;
            };

            userCreationResult.IsSuccess = true;
            userCreationResult.Errors = "User Created";

            return userCreationResult;
        }
    }
}
