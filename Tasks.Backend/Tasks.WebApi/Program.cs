using Microsoft.Extensions.Configuration;
using System.Reflection;
using Tasks.Application;
using Tasks.Application.Common.Mappings;
using Tasks.Persistense;
using Tasks.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ITasksDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
