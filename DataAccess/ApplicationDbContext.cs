using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Itinerary> Itineraries { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Accomodation> Accomodations { get; set; }

    public virtual DbSet<Transportation> Transportations { get; set; }
}
