using API.Attributes;
using API.Extensions;
using Entities.CustomEntities.User;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await userService.GetUsers();
            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var response = await userService.GetUser(userId);
            return response.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]AddUser userToAdd)
        {
            var response = await userService.AddUser(userToAdd);
            return response.ToHttpResponse();
        }

        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId,[FromBody]UpdateUser userToUpdate)
        {
            var response = await userService.UpdateUser(userId, userToUpdate);
            return response.ToHttpResponse();
        }

        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await userService.RemoveUser(userId);
            return response.ToHttpResponse();
        }
        [HttpPatch]
        [Route("{userId:int}")]
        public async Task<IActionResult> InactiveUser(int userId)
        {
            var response = await userService.InactiveUser(userId);
            return response.ToHttpResponse();
        }

    }
}