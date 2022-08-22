using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulApi_Repo.Models;
using RestFulApi_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulApi_Repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentImplemationService _studentService;
        public StudentController(IStudentImplemationService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudentDetails()
        {
            try
            {
                return Ok(_studentService.GetStudent());
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]

        public IActionResult GetStudentById(int Id)
        {
            try
            {
                return Ok(_studentService.GetStudentById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel collegeObj)
        {
            try
            {
                return Ok(_studentService.AddStudentDetails(collegeObj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
;            }
        }

        [HttpDelete]

        public IActionResult DeleteStudent(int Id)
        {
            try
            {
                return Ok(_studentService.DeleteStuddent(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
