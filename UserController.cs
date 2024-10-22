using DTOAndSRM.Service;
using Microsoft.AspNetCore.Mvc;

namespace DTOAndSRM;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase 
{
    [HttpGet]
    public IActionResult GetUsers()
        => Ok(ApiResponse<IEnumerable<ReadUser>>.Success(null, userService.GetAllUsers()));

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        ReadUser? res = userService.GetUserById(id);
        return res != null
            ? Ok(ApiResponse<ReadUser?>.Success(null, res))
            : NotFound(ApiResponse<ReadUser?>.Fail(null, null));
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] string name,int age, string email, string phoneNumber)
    {
        CreateUser info = new CreateUser(name, age, email,phoneNumber);
        bool res = userService.CreateUser(info);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }

    [HttpPut]
    public IActionResult UpdateCourse(UpdateUser info)
    {
        bool res = userService.UpdateUser(info);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        bool res = userService.DeleteUser(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}