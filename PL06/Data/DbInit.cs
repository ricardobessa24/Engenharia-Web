using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using PL06.Models;

namespace PL06.Data
{
    public class DbInit
    {
        public static void Initialize(PL06Context context)
        {
            context.Database.EnsureCreated();

            //Look for any categories
            if (context.Students.Any())
            {
                return;  //DB has been seeded
            }

            Dictionary<string, List<Student>> collection = new Dictionary<string, List<Student>>();

            using (StreamReader sr = File.OpenText("Data\\studentslist_pl06.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(";");  //number;name;course
                    if (collection.ContainsKey(parts[2]) == false)
                    {
                        collection.Add(parts[2], new List<Student>());
                    }
                    collection[parts[2]].Add(new Student { Number = Convert.ToInt32(parts[0]), Name = parts[1] });

                }
                foreach (string course in collection.Keys)
                {
                    context.Courses.Add(new Course { Name = course });
                }
                context.SaveChanges();

                foreach (KeyValuePair<string, List<Student>> aux in collection) //create students in database
                {
                    foreach (Student s in aux.Value)
                    {
                        s.CourseId = context.Courses.Single(courses => courses.Name == aux.Key).Id;
                        context.Students.Add(s);
                    }
                }
                context.SaveChanges();
            }

        }
    }
}
