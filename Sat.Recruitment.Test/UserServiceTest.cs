
using Moq;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Service;
using Sat.Recruitment.Api.Services.Helpers;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;
using System.Collections.Generic;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserServiceTest
    {
        private UserService _userService;
        private Mock<IUserValidator> userValidatorMock = new Mock<IUserValidator>();
        private Mock<IUserTypeLogicCreator> userTypeLogicCreatorMock = new Mock<IUserTypeLogicCreator>();
        private Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
        private Mock<IUserDuplicateValidator> userDuplicateValidatorMock = new Mock<IUserDuplicateValidator>();
        private Mock<IEmailHelper> emailHelperMock = new Mock<IEmailHelper>();

        public UserServiceTest()
        {
            _userService = new UserService(
                userValidatorMock.Object,
                userTypeLogicCreatorMock.Object,
                userRepositoryMock.Object,
                userDuplicateValidatorMock.Object,
                emailHelperMock.Object
                );
        }

        [Fact]
        public void Should_Create_User_With_Valid_User()
        {
            // Arrange
            var testUser = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal.ToString(),
                Money = 124
            };
            userValidatorMock.Setup(u => u.Validate(testUser)).Returns(new List<string>());

            var normalUserTypeLogicMock = new Mock<INormalUserTypeLogic>();
            userTypeLogicCreatorMock.Setup(u => u.GetUserTypeLogicInstance(UserType.Normal)).Returns(normalUserTypeLogicMock.Object);

            var result = _userService.Create(testUser);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

    }
}
