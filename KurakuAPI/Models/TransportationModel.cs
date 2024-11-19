namespace KurakuAPI.Models;

public class TransportationModel
{
    public long Id { get; set; }

    public string TransportType { get; set; }

    public string Company { get; set; }

    public DateTime DepartureTime { get; set; }

    public string FromLocation { get; set; }

    public string ToLocation { get; set; }
}
