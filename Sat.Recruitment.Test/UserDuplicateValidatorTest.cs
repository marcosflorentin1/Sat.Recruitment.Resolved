using Sat.Recruitment.Api.Enums;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Validations.UserStateValidation;
using System.Collections.Generic;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserDuplicateValidatorTest
    {
        UserDuplicateValidator userDuplicateValidator;

        public UserDuplicateValidatorTest()
        {
            userDuplicateValidator = new UserDuplicateValidator();
        }

        [Fact]
        public void Should_Return_False_With_Duplicated_User()
        {
            var testUsers = new List<User>
            {
                new User
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354215",
                    UserType = UserType.Normal.ToString(),
                    Money = 124
                },
                new User
                {
                    Name = "Agustina",
                    Email = "poke@hotmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354325",
                    UserType = UserType.Normal.ToString(),
                    Money = 41
                }
            };

            var isDuplicated = userDuplicateValidator.IsDuplicateUser(testUsers[0], testUsers);

            Assert.True(isDuplicated);
        }
    }
}
