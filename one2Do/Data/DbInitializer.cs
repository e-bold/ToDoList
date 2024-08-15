using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using one2Do.Models;
using one2Do.Models.ToDoModels;
using one2Do.Models.QuoteModels;
using System;
using System.Linq;

namespace one2Do.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<one2doDbContext>();

                // Seed Quotes if they are not already in the database
                if (!context.Quotes.Any())
                {
                    var quotes = new Quote[]
                    {
                        new Quote { Text = "You're doing great! Keep it up!" },
                        new Quote { Text = "Small steps lead to big changes." },
                        new Quote { Text = "Every day is a fresh start." },
                        new Quote { Text = "Stay focused and keep pushing forward." },
                        new Quote { Text = "Believe in yourself and all that you are." },
                        new Quote { Text = "Consistency is the key to success." },
                        new Quote { Text = "Your potential is limitless." },
                        new Quote { Text = "Take it one step at a time." },
                        new Quote { Text = "Hard work pays off." },
                        new Quote { Text = "You are capable of amazing things." },
                        new Quote { Text = "Keep going, no matter what." },
                        new Quote { Text = "Success is the sum of small efforts, repeated day in and day out." },
                        new Quote { Text = "The harder you work for something, the greater you’ll feel when you achieve it." },
                        new Quote { Text = "Don't watch the clock; do what it does. Keep going." },
                        new Quote { Text = "Start where you are. Use what you have. Do what you can." },
                        new Quote { Text = "Dream big and dare to fail." },
                        new Quote { Text = "Don't wait for opportunity. Create it." },
                        new Quote { Text = "Success doesn't come from what you do occasionally. It comes from what you do consistently." },
                        new Quote { Text = "The secret of getting ahead is getting started." },
                        new Quote { Text = "It always seems impossible until it's done." },
                        new Quote { Text = "Motivation gets you started. Habit keeps you going." },
                        new Quote { Text = "Don't be afraid to give up the good to go for the great." },
                        new Quote { Text = "What you do today can improve all your tomorrows." },
                        new Quote { Text = "Do something today that your future self will thank you for." },
                        new Quote { Text = "The only way to achieve the impossible is to believe it is possible." },
                        new Quote { Text = "You don't have to be perfect to be amazing." },
                        new Quote { Text = "Success is not the key to happiness. Happiness is the key to success." },
                        new Quote { Text = "You are stronger than you think." },
                        new Quote { Text = "Push yourself, because no one else is going to do it for you." },
                        new Quote { Text = "The journey of a thousand miles begins with one step." }
                    };

                    foreach (Quote q in quotes)
                    {
                        context.Quotes.Add(q);
                    }
                    context.SaveChanges();
                }

                // Seed Categories if they are not already in the database
                if (!context.Categories.Any())
                {
                    var categories = new Category[]
                    {
                        new Category { Name = "Household" },
                        new Category { Name = "Errands" },
                        new Category { Name = "Professional" },
                        new Category { Name = "Personal" }
                    };

                    foreach (Category c in categories)
                    {
                        context.Categories.Add(c);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
