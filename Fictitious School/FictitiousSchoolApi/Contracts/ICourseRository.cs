using SchoolApi.Data.Entites;
using System.Collections.Generic;

namespace SchoolApi.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();

        Course GetCourseById(int id);

        void InsertCourse(Course course);

        void DeleteCourse(int Id);

        void UpdateCourse(Course course);

        bool Save();
    }
}