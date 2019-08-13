using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace giantbombTest.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new dbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                // Look for any movies.
                if (context.GameItem.Any())
                {
                    return;   // DB has been seeded
                }
                
                context.GameItem.AddRange(
                    new GameItem
                    {
                        GbID = 2950,
                        Platform = "Xbox 360",
                        Name = "Assassin's Creed",
                        DateAdded = DateTime.Parse("2019-6-16")
                    },
                    new GameItem
                    {
                        GbID = 52633,
                        Platform = "PC",
                        Name = "Call of Duty: Infinite Warfare",
                        DateAdded = DateTime.Parse("2019-6-16")
                    },
                    new GameItem
                    {
                        GbID = 56733,
                        Platform = "Nintendo Switch",
                        Name = "Super Mario Odyssey",
                        DateAdded = DateTime.Parse("2019-6-16")
                    }

                );
                context.SaveChanges();
                

        }
         
        }

    }
}
