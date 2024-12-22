using Microsoft.EntityFrameworkCore;
using TesteTecnicoGrendene.Configuration;
using TesteTecnicoGrendene.Data;
using TesteTecnicoGrendene.Helpers;
using TesteTecnicoGrendene.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddDbContextConfig();

builder.Services.AddSingleton<IPasswordHelper, PasswordHelper>();

builder.AddDataConfig();

builder.Services.AddControllers();

builder.AddAuthConfig();
builder.AddCorsConfig();
builder.AddAPIVersionConfig();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddSwaggerConfig();

var app = builder.Build();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseCors("Development");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}



app.Run();
