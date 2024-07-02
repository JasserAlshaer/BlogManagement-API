using BlogManagement_Core.DTOs.Authantication;
using BlogManagement_Core.DTOs.Blogs;
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
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetBlogDetails([FromRoute]int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Please Send Blog Id");
            }
            else
            {
                try
                {
                    var obj = await _service.GetBlogDetailsByIdInMemoryExecution(Id);
                    return StatusCode(200, obj);
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetBlogDetailsSecondWay([FromRoute] int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Please Send Blog Id");
            }
            else
            {
                try
                {
                    var obj = await _service.GetBlogDetailsByIdInQuerable(Id);
                    return StatusCode(200, obj);
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
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
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDTO input)
        {
            if (input == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.CreateNewBlog(input);
                    return StatusCode(201, "New Blog Has Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogDTO input)
        {
            if (input == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.UpdateBlog(input);
                    return StatusCode(200, "Blog Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateBlogApprovement([FromQuery]int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.UpdateBlogApprovment(Id,value);
                    return StatusCode(200, "Blog Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateBlogAactivation([FromQuery] int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.UpdateBlogActivation(Id, value);
                    return StatusCode(200, "Blog Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _service.DeletBlog(Id);
                    return StatusCode(200, "Blog Has Been Delted / Removed");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

    }
}
