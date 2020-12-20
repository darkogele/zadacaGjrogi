using Microsoft.EntityFrameworkCore;
using SchoolApi.Data.Entites;
using SchoolApi.Dto;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolApi.Data.SchoolDbContext
{
    public class Seed
    {
        public static async Task SeedCourses(SchoolDbContext context)
        {
            if (await context.Courses.AnyAsync()) return;

            var coursesData = await File.ReadAllTextAsync("Data/SchoolDbContext/courses.json");
            var courses = JsonSerializer.Deserialize<List<CourseDto>>(coursesData);

            context.Database.OpenConnection();

            foreach (var course in courses)
            {
                var courseForDb = new Course
                {
                    Name = course.Name,
                    Id = course.Id,
                    Dates = string.Join(" ",course.Dates)
                };

                await context.Courses.AddAsync(courseForDb);
            }

            context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Courses ON;");
          
            await context.SaveChangesAsync();

            context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Courses OFF");

            context.Database.CloseConnection();
        }
    }
}