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
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeImplemation _collegeService;

        public CollegeController(ICollegeImplemation collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpGet]
        public IActionResult GetCollegeDetails()
        {
            try
            {
                return Ok(_collegeService.GetCollege());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]

        public IActionResult GetCollegeById(int Id)
        {
            try
            {
                return Ok(_collegeService.GetStudent(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public IActionResult AddCollege(CollegeModel collegeObj)
        {
            try
            {
                return Ok(_collegeService.AddCollegeDetails(collegeObj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete]

        public IActionResult DeleteCollege(int Id)
        {
            try
            {
                return Ok(_collegeService.DeleteCollege(Id));
            }
            catch (Exception ex)
            {

              return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateCollege(CollegeModel collegeObj, int Id)
        {
            try
            {
                return Ok(_collegeService.UpdateCollege(collegeObj, Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
    }
}
