using Ascend.Auth.UserPermission.Business.Extensions;
using Ascend.Auth.UserPermission.Business.Services;
using Ascend.Auth.UserPermission.Business.Services.Interfaces;
using Ascend.Auth.UserPermission.Data.Repositories;
using Ascend.Auth.UserPermission.Data.Repositories.Interfaces;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Host.ConfigureLogging(host => {
    host.ClearProviders();
    host.AddConsole();

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddUPDbContext("Server=localhost;Database=UserPermission;Encrypt=False;Trusted_Connection=True");

// DI for services and repositories 
builder.Services.AddTransient<IPermissionsRepository, PermissionsRepository>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IContentSetService, ContentSetService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(sg =>
{
    sg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "User Permission Service", Version = "v1" });
    sg.CustomSchemaIds(x => x.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? x.Name);

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Ascend.Auth.UserPermission.WebAPI.xml");
    sg.IncludeXmlComments(filePath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c=> c.SwaggerEndpoint("v1/swagger.json", "User Permission Service Synchronous  API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
