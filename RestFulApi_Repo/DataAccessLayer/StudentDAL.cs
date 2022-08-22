using RestFulApi_Repo.Data;
using RestFulApi_Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulApi_Repo.DataAccessLayer
{
    public interface IStudentDAL
    {
        IEnumerable<StudentEntities> GetStudents();
        StudentEntities GetStudentById(int Id);
        Task<StudentEntities> AddStudentDetails(StudentEntities collegeObj);

        StudentEntities DeleteStudent(int Id);

        StudentEntities UpdateStudent(StudentEntities collegeObj, int Id);
    }

    public class StudentImplantationDAL : IStudentDAL
    {
        public readonly ApplicationDbContext _Context;

        public StudentImplantationDAL(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<StudentEntities> AddStudentDetails(StudentEntities collegeObj)
        {
            var result = await _Context.Students.AddAsync(collegeObj);
            _Context.SaveChanges();
            return result.Entity;
        }

        public StudentEntities DeleteStudent(int Id)
        {
            var res = _Context.Students.FirstOrDefault(s => s.Id == Id);
            if (res != null)
            {
                _Context.Students.Remove(res);
                _Context.SaveChanges();
                return res;

            }
            return null;
        }

        public StudentEntities GetStudentById(int Id)
        {
            return _Context.Students.FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<StudentEntities> GetStudents()
        {
            return _Context.Students.ToList();
        }

        public StudentEntities UpdateStudent(StudentEntities collegeObj, int Id)
        {
            var updatedata = _Context.Students.Where(s => s.Id == Id).ToList();
            foreach (var item in updatedata)
            {
                if (item.Id == Id)
                {
                    item.DOB = collegeObj.DOB;
                    item.Email = collegeObj.Email;
                    item.Phone = collegeObj.Phone;
                    item.FirstName = collegeObj.FirstName;
                    item.LastName = collegeObj.LastName;
                    item.CollegeId = collegeObj.CollegeId;

                    var update = _Context.Students.Update(item);
                    _Context.SaveChanges();
                    return update.Entity;
                }
            }
            return collegeObj;
        }
    }
}
