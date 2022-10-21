using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsProject.DTO;
using StudentsProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly CollegeDbContext DbContext;

        public CollegeController(CollegeDbContext collegeDbContext)
        {
            this.DbContext = collegeDbContext;
        }

        [HttpGet("GetCourses")]
        public ActionResult<IEnumerable<CourseDTO>> GetCourses()
        {

            var courses = DbContext.Courses.ToList();
            if (courses == null)
            {
                return NotFound();
            }
            var Dto = courses.Select<Course, CourseDTO>(x => CourseMap(x)).ToList();
            return Dto;
        }

        public static CourseDTO CourseMap(Course course)
        {
            return new CourseDTO()
            {
                Name = course.Name,
                Professor = course.Professor,
                Description = course.Description
            };
        }

        [HttpDelete("DeleteCourse")]
        public ActionResult DeleteCourse(string Name)
        {
            var course = DbContext.Courses.FirstOrDefault(x => x.Name == Name);
            if (course == null)
                return NotFound();

            DbContext.Courses.Remove(course);
            DbContext.SaveChanges();

            return Ok();
        }



        [HttpPost("CreateCourse")]
        public ActionResult CreateCourse(CourseDTO course)
        {
            DbContext.Courses.Add(new Course
            {
                Name = course.Name,
                Professor = course.Professor,
                Description = course.Description
            });
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("CreateStudent")]
        public ActionResult CreateStudent(StudentDTO student)
        {
            DbContext.Students.Add(new Student
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone
            });
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("GetStudents")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {

            var students = DbContext.Students.ToList();
            if (students == null)
            {
                return NotFound();
            }
            var Dto = students.Select<Student, StudentDTO>(x => StudentMap(x)).ToList();
            return Dto;
        }

        public static StudentDTO StudentMap(Student student)
        {
            return new StudentDTO()
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone
            };
        }

        [HttpGet("GetStudentsByCourse")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudentsByCourse(string CourseID)
        {
            var course = DbContext.Courses.FirstOrDefault(x => x.Name == CourseID);
            var students = DbContext.Students.ToList().Where(x => x.courses.Contains(course));
            if (students == null)
            {
                return NotFound();
            }
            var Dto = students.Select<Student, StudentDTO>(x => StudentMap(x)).ToList();
            return Dto;
        }

        [HttpPut("AddStudentToCourse")]
        public ActionResult AddStudentToCourse(AddStudentToCourseDto addStudentToCourseDto)
        {
            var student = DbContext.Students.FirstOrDefault(x => x.Name == addStudentToCourseDto.StudentName);
            var course = DbContext.Courses.FirstOrDefault(x => x.Name == addStudentToCourseDto.CourseName);

            if(course == null || student == null) {
                return NotFound();
            }
            student.courses.Add(course);
            //course.Students.Add(student);
            DbContext.Courses.Update(course);
            //DbContext.Students.Update(student);
            DbContext.SaveChanges();

            return Ok();

        }






    }
}
