using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Group4LMS.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Group4LMSContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Group4LMSContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "I am just right",
                        Author = "McPhail, David",
                        ISBN10 = "0823441067",
                        ISBN13 = "9780823441068",
                        Genre = "Children's stories"
                    },

                    new Book
                    {
                        Title = "All for one",
                        Author = "De la Cruz, Melissa",
                        ISBN10 = "0525515887",
                        ISBN13 = "9780525515883",
                        Genre = "Young adult fiction"
                    },

                    new Book
                    {
                        Title = "Llama destroys the world",
                        Author = "Stutzman, Jonathan",
                        ISBN10 = "1250303176",
                        ISBN13 = "9781250303172",
                        Genre = "Fiction"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
