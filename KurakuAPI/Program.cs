using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

#region OData Model Declarations

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ProfileModel>("Profile");
modelBuilder.EntitySet<ActivityModel>("Activity");
modelBuilder.EntitySet<ItineraryModel>("Itinerary");
modelBuilder.EnableLowerCamelCase();

#endregion


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers().AddOData(options =>
    options.EnableQueryFeatures().AddRouteComponents("api", modelBuilder.GetEdmModel()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("KURAKU_DB"), ServerVersion.Parse("8.0.34-mysql")));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

#region Dependency Registrations

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IItineraryService, ItineraryService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();