using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KurakuAPI.Controllers;

[Route("api/users")]
public class UserController(IUserService userService) : ODataController
{
    [HttpGet]
    [EnableQuery]
    public IQueryable<UserModel> Get()
    {
        return userService.GetUsers();
    }
}
