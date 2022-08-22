using RestFulApi_Repo.DataAccessLayer;
using RestFulApi_Repo.Entities;
using RestFulApi_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulApi_Repo.Services
{
    public interface IStudentImplemationService
    {
        IEnumerable<StudentModel> GetStudent();

        StudentModel GetStudentById(int Id);

        Task<StudentModel> AddStudentDetails(StudentModel collegeObj);

        StudentModel DeleteStuddent(int Id);

        StudentModel UpdateStudent(StudentModel collegeObj, int id);
    }

    public class StudentImplantation : IStudentImplemationService
    {
        private readonly IStudentDAL _StudentDA;

        public StudentImplantation(IStudentDAL StudentDA)
        {
            _StudentDA = StudentDA;
        }
        public StudentModel GetStudentById(int Id)
        {
            var student = _StudentDA.GetStudentById(Id);
            if(student != null)
            {
                return new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Phone = student.Phone,
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<StudentModel> GetStudent()
        {
            var all_Student = _StudentDA.GetStudents();
            List<StudentModel> list = new();
            foreach (var Student in all_Student)
                list.Add(new StudentModel
                {
                    Id = Student.Id,
                    FirstName = Student.FirstName,
                    LastName = Student.LastName,
                    Email = Student.Email,
                    Phone = Student.Phone,

                });
            return list;
        }

        public async Task<StudentModel> AddStudentDetails(StudentModel collegeObj)
        {
            var Object = new StudentEntities
            {

                FirstName = collegeObj.FirstName,
                LastName = collegeObj.LastName,
                Email = collegeObj.Email,
               DOB = collegeObj.DOB,
                Phone = collegeObj.Phone,
               
                CollegeId = collegeObj.CollegeId
            };
            var res = await _StudentDA.AddStudentDetails(Object);
            return new StudentModel
            {
                Id = res.Id
            };
        }

        public StudentModel DeleteStuddent(int Id)
        {
            var removeData = _StudentDA.DeleteStudent(Id);
            return new StudentModel
            {
                FirstName = removeData.FirstName,
                LastName = removeData.LastName,
                Email = removeData.Email,
                Phone = removeData.Phone,
                DOB = removeData.DOB,
                CollegeId = removeData.CollegeId
            };
        }

        public StudentModel UpdateStudent(StudentModel collegeObj, int id)
        {
            throw new NotImplementedException();
        }
    }
    }

