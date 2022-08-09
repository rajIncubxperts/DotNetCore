using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using   WebApplicatioTemp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicatioTemp.Controllers
{   
    [ApiController]
    //[Route("api/[controller]")]  //Working with attribute routing we have to specify Decorator  //This method called with below route.
    [Route("Student")]
    public class StudentsController : ControllerBase
    {
         static List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "kalpesh",
                    Age = 34,
                    City = "pune"
                },
                // new Student()
                //{
                //    Id = 2,
                //    Name = "Raja",
                //    Age = 23,
                //    City = "Nashik"
                //}
            };


        //[Route("getStudentsdata")]
        [Route("getStudentsdata")]
        [HttpGet]
        public ActionResult<Student> GetStudent()
        {

            return Ok(students);
        }

        [Route("getStudentdata")]
        [HttpGet]
        public  ActionResult<Student> GetStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
                return BadRequest("No Student Found!");

            return Ok(student);
        }


        [Route("addStudentdata")]
        [HttpPost]
        public  ActionResult<Student> AddStudent(Student request)
        {

            students.Add(request);
            return Ok(students);
        }


        [Route("updateStudentdata")]
        [HttpPut]
        public  ActionResult<Student> UpdateStudent(Student request)
        {
            var student = students.Find(s => s.Id == request.Id);
            if (student == null)
                return BadRequest("No Student Found!");
            student.Name = request.Name;
            student.Age = student.Age;
            student.City = request.City;
            return Ok(student);    //return a student list
        }


        [Route("Deletetudentdata")]
        [HttpDelete]
        public  ActionResult<Student> DeleteStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
                return BadRequest("No Student Found!");
            students.Remove(student);
            return Ok(student);
        }

    }
}
