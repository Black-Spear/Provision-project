using Microsoft.AspNetCore.Mvc;
namespace Provision.api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ServiceResponse<List<GetUserResponseDto>>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var qrCodes = await _userService.GetAllUsers();
        if (!qrCodes.Success)
        {
            return NotFound(qrCodes.Message);
        }
        return Ok(qrCodes);
    }

    /// <summary>
    /// Retrieves a single User by ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ServiceResponse<GetUserResponseDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetSingle(int id)
    {
        var qrCode = await _userService.GetUserById(id);
        if (!qrCode.Success)
        {
            return NotFound(qrCode);
        }
        return Ok(qrCode);
    }

    /// <summary>
    /// Retrieves a single User by target string.
    /// </summary>
    [HttpGet("getLoginQrCodeByString/{targetString}")]
    [ProducesResponseType(typeof(ServiceResponse<GetUserResponseDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetByString(string targetString)
    {
        var qrCode = await _userService.GetUserByString(targetString);
        if (!qrCode.Success)
        {
            return NotFound(qrCode);
        }
        return Ok(qrCode);
    }

    /// <summary>
    /// Adds a new User.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ServiceResponse<List<GetUserResponseDto>>), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] AddUserRequestDto newLoginQrCode)
    {
        var serviceResponse = await _userService.AddUser(newLoginQrCode);

        if (!serviceResponse.Success)
        {
            return BadRequest(serviceResponse);
        }
        return CreatedAtAction(nameof(GetAll), null, serviceResponse);
    }

    /// <summary>
    /// Deletes a User by ID.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ServiceResponse<GetUserResponseDto>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _userService.DeleteUserById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Logs in using a userName and password.
    /// </summary>
    [HttpGet("login")]
    [ProducesResponseType(typeof(ServiceResponse<GetUserResponseDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PerformLogin(string targetQrString, string password)
    {
        var response = await _userService.Login(targetQrString, password);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}
