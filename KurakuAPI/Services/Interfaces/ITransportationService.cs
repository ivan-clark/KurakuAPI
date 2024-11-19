using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface ITransportationService
{
    public IQueryable<TransportationModel> GetTransportations();
}
