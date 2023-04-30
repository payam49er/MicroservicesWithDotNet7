using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepData
{
    public static async Task PrepPopulationAsync(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        await SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }
    
    private static async Task SeedData(AppDbContext? context)
    {
        //check to see if there is any data in the db
        if (context != null && ! await context.Platforms.AnyAsync())
        {
            Console.WriteLine("---> Seeding data");
            await context.Platforms.AddRangeAsync(
                new Platform {Id = 1, Name = "Dot Net", Cost = "Free", Publisher = "MS"},
                new Platform {Id = 2, Name = "SQL Server Express", Publisher = "MS", Cost = "Free"},
                new Platform { Id = 3,Name = "Kubernetes",Publisher = "Cloud Native", Cost = "Free"}
                );

            //save the changes in the db
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("---> There is seeding data in the db already!");
        }
    }
}