using HierarchyAPI.Role_Entity.Models;
using HierarchyAPI.Role_Entity.Models.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IRoleQueryRepository,RoleQuery>();
builder.Services.AddScoped<IRoleCommandsRepository,RoleCommandsRepository>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddDbContext<OrgaContext>(options => {
    options.UseNpgsql(builder.Configuration.
        GetConnectionString("Postgres"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();


//app.UseMiddleware<LoggingInterceptorMiddleware>();
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
