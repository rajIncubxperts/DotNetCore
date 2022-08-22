using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Non_GenericTask.Models;
using Non_GenericTask.Repository;
using Non_GenericTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Non_GenericTask.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase 
    {
        private readonly IStudent _student; 
        public StudentController(IStudent student) 
        {
            _student = student;                      //// with Dependency Injection

        }

        //private readonly StudentImplantation studentService;
        //public StudentController()
        //{
        //    studentService = new StudentImplantation(); //// without Dependency Injection
        //}

        //////With Object Service
        //[HttpGet]
        //public async Task<ActionResult> GetStudent()
        //{
        //    //var res = (await _student.GetStudents());
        //    //return Ok(res);
        //    var res =  await studentService.GetStudents();
        //    return Ok(res);
        //}

        //// GET: api/[controller]/5
        //[HttpGet("{Id}")]
        //public async Task<ActionResult> GetStudentByID(int Id)
        //{
        //    var res = await studentService.GetStudent(Id);
        //    if (res == null)
        //    {
        //        return BadRequest("No Student Found!");
        //    }
        //    return Ok(res);
        //}


        //////With DI Service
        [HttpGet]
        public async Task<ActionResult> GetAlLStudent()
        {
            try
            {
                var res = (await _student.GetStudents());
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET: api/[controller]/5
        [HttpGet("{Id}")]
        public async Task<ActionResult> GettheStudentByID(int Id)
        {
            try
            {
                var res = await _student.GetStudent(Id);
                if (res == null)
                {
                    return BadRequest("No Student Found!");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            var res = await _student.AddStudent(student);
            return Ok(res);
        }

        // DELETE: api/[controller]/5
        [HttpDelete]

        public async Task<ActionResult> DeleteStudentByID(int Id)
        {
            try
            {
                var res = await _student.DeleteStudent(Id);
                if (res == null)
                {
                    return BadRequest("No Student Found!");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]

        public async Task<ActionResult> UpateStudentByID(Student student)
        {
            try
            {
                var res = await _student.UpdateStudent(student);
                //if (res == null)
                //{
                //    return BadRequest("No Student Found!");
                //}

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
