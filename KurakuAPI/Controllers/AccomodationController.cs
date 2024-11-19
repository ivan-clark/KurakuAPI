using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KurakuAPI.Controllers;

[Authorize]
public class AccomodationController(IAccomodationService accomodationService) : ODataController
{
    [EnableQuery]
    public IQueryable<AccomodationModel> Get ()
    {
        return accomodationService.GetAccomodations();
    }
}
