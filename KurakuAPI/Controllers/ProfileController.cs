using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KurakuAPI.Controllers;

[Authorize]
public class ProfileController(IProfileService profileService) : ODataController
{
    [EnableQuery]
    public IQueryable<ProfileModel> Get()
    {
        return profileService.GetProfiles();
    }
}
