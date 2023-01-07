using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PL04.Models;

namespace PL04.Data
{
    public class DbInitializer
    {
        public static void Initialize(PL04Context context)
        {
            context.Database.EnsureCreated();
            //look for any categories
            if (context.Category.Any())
            {
                return;
            }
            var categories = new Category[]
            {
                new Category {Name = "Programming", description = "Algorithms and programming area courses", state = true, Date = DateTime.Now.AddDays(-1)},
                new Category {Name = "Administration", description = "Public dministration and business management courses", state = true, Date=DateTime.Now.AddDays(-2)},
                new Category {Name = "Communication", description = "Business and institutional communication courses", state = true, Date=DateTime.Now.AddDays(-3)}
            };
            foreach(Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name = "Web Engineering",
                    Description = "Create new sites using ASP.NET",
                    Cost = 50, Credits = 6,
                    CategoryId = categories.Single(categories=>categories.Name=="Programming").id
                },
                new Course
                {
                    Name = "Strategic Leadership and Management",
                    Description = "Leadership and Business Skill for immediate Impact",
                    Cost = 100, Credits = 6,
                    CategoryId = categories.Single(categories=>categories.Name=="Administration").id
                },
                new Course
                {
                    Name = "Master in Corporate Communication",
                    Description = "Organizing Communication Department",
                    Cost = 80, Credits = 10,
                    CategoryId = categories.Single(categories=>categories.Name=="Communication").id
                }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}
