using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

#region OData Model Declarations

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EnableLowerCamelCase();
modelBuilder.EntitySet<UserModel>("users");

#endregion


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("KURAKU_DB"), ServerVersion.Parse("8.0.34-mysql")));

builder.Services.AddControllers().AddOData(
    options => options.EnableQueryFeatures().AddRouteComponents("api", modelBuilder.GetEdmModel()));

#region Dependency Registrations

builder.Services.AddScoped<IUserService, UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
