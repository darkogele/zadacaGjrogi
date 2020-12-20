using SchoolApi.Contracts;
using SchoolApi.Data.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Data.SchoolDbContext
{
    public class CourseRository : ICourseRepository
    {
        private readonly SchoolDbContext _context;
        public CourseRository(SchoolDbContext context)
        {
            _context = context;
        }

        public void DeleteCourse(int Id)
        {
             _context.Companies.Find(Id).DeletedOn = DateTime.Now;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.DeletedOn.Equals(null)
                && c.Id.Equals(id));
        }

        public void InsertCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 1;
        }

        public void UpdateCourse(Course course)
        {
            var coursetFromDb = _context.Courses.Find(course.Id);
            coursetFromDb.ModifedOn = DateTime.Now;
            coursetFromDb.Name = course.Name;
        }
    }
}