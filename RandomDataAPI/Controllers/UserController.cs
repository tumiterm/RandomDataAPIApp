using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UserSchema.dll.UserDTO;
using Utilities.dll.Contract;
using Utilities.dll.Helper;

namespace RandomDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserContext _apiHelper;
        private readonly ILogger<UserController> _logger;

        public UserController(IConfiguration configuration, IUserContext apiHelper, ILogger<UserController> logger)
        {
            _configuration = configuration;

            _apiHelper = apiHelper;

            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetAsync()
        {
            try
            {
                HttpResponseMessage response = await _apiHelper.SendGetRequestAsync(_configuration["APIConfigs:BaseUrl"]);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    UserDTO user = JsonSerializer.Deserialize<UserDTO>(responseBody);

                    if (user == null)
                    {
                        return NotFound("No user data found.");
                    }

                    return Ok(user);
                }
                else
                {
                    return Problem(detail: $"Error: {response.StatusCode}", statusCode: (int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
