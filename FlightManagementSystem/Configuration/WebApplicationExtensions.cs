using FlightManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Configuration
{
    public static class WebApplicationExtensions
    {
        public static WebApplication? ConfigureWebApplication (this WebApplication? app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FlightManagementContext>();
                context.Database.Migrate();
            }

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

            return app;
        }
    }
}
