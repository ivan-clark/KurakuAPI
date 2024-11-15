namespace KurakuAPI.Models;

public class AccomodationModel
{
    public long Id { get; set; }

    public string HotelName { get; set; }

    public string Address { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set;}
}
