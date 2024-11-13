using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KurakuAPI.Controllers;

[Authorize]
public class ActivityController(IActivityService activityService) : ODataController
{
    [EnableQuery]
    public IQueryable<ActivityModel> Get()
    {
        return activityService.GetActivities();
    }
}
