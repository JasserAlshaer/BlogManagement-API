using BlogManagement_Core.DTOs.Authantication;
using BlogManagement_Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserBlogs()
        {
            try
            {
                return StatusCode(201, await _service.GetBlogs());
            }
            catch (Exception ex)
            {
                return StatusCode(503, $"Error Orrued {ex.Message}");
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserBlogsByRepos()
        {
            try
            {
                return StatusCode(201, await _service.GetBlogsByRepos());
            }
            catch (Exception ex)
            {
                return StatusCode(503, $"Error Orrued {ex.Message}");
            }
        }
        [HttpPost]
        [Route("CreateNewAccount")]
        public async Task<IActionResult> CreateNewAccount([FromBody] RegistrationDTO input)
        {
            if (input == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.RegisterNewClient(input);
                    return StatusCode(201, "New Account Has Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

    }
}
