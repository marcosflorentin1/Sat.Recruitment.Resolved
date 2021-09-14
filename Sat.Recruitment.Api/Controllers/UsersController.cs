using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Service;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<Result> CreateUser(User newUser)
        {
            var creationResult = _userService.Create(newUser);

            return await Task.FromResult(creationResult);
        }
    }
}
