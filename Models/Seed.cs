
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TodoApi.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {
                
                if (context.Games.Any())
                {
                    return;   
                }
                context.Games.AddRange(
                    new TodoItem
                    {
                        Id = 1,
                        Title = "Cyberpunk",
                        Producent = "CD Projekt Red",
                        Price = 49.99,
                        PlayTime = 600
                    },
                    new TodoItem
                    {
                        Id = 2,
                        Title = "Dishonored",
                        Producent = "Bethesda",
                        Price = 4.99,
                        PlayTime = 300
                    },
                    new TodoItem
                    {
                        Id = 3,
                        Title = "Dying Light",
                        Producent = "Techland",
                        Price = 9.99,
                        PlayTime = 1200
                    },
                    new TodoItem
                    {
                        Id = 4,
                        Title = "Settlers III",
                        Producent = "Blue Byte Software",
                        Price = 2.99,
                        PlayTime = 1000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
