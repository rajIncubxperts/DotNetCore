using Microsoft.EntityFrameworkCore;
using RestFulApi_Repo.Data;
using RestFulApi_Repo.DataAccessLayer;
using RestFulApi_Repo.Entities;
using RestFulApi_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulApi_Repo.Services
{
    public interface ICollegeImplemation 
    {
       public IEnumerable<CollegeModel> GetCollege();
        CollegeModel GetStudent(int Id);
       Task<CollegeModel> AddCollegeDetails(CollegeModel collegeObj);

        CollegeModel DeleteCollege(int Id);

        CollegeModel UpdateCollege(CollegeModel collegeObj, int id);
    }
    public class CollegeImplantation : ICollegeImplemation
    {
        private readonly ICollegeDAL _collegeDA;

        public CollegeImplantation(ICollegeDAL collegeDA)
        {
            _collegeDA = collegeDA;       // with Dependency Injection
        }

        public async Task<CollegeModel> AddCollegeDetails(CollegeModel collegeObj)
        {
            var Object = new CollegeEntities
            {

                Name = collegeObj.Name,
                Address = collegeObj.Address,
                University = collegeObj.University,
                District = collegeObj.District,
            };
            var res = await _collegeDA.AddCollegeDetails(Object);
            return new CollegeModel
            {
                Id = res.Id
        };
        }

        public CollegeModel DeleteCollege(int Id)
        {
            var removeData = _collegeDA.DeleteCollege(Id);
            return new CollegeModel
            {
                Id = removeData.Id,
                Name = removeData.Name,
                Address = removeData.Address,
                University = removeData.University,
                District = removeData.District,
            };

        }

        public IEnumerable<CollegeModel> GetCollege()
        {
            var all_College = _collegeDA.GetCollege();
            List<CollegeModel> list = new();
            foreach (var college in all_College)
                list.Add(new CollegeModel
                {
                    Id = college.Id,
                    Name = college.Name,
                    Address = college.Address,
                    University = college.University,
                  District = college.District,
                });
            return list;
        }

        public CollegeModel GetStudent(int Id)
        {
           var college = _collegeDA.GetStudent(Id); 

            if(college != null)
            {
                return new CollegeModel
                {
                    Id = college.Id,
                    Name = college.Name,
                    Address = college.Address,
                    University = college.University,
                };
            }
            else
            {
                return null;
            }
        }

        public CollegeModel UpdateCollege(CollegeModel collegeObj, int id)
        {
            var Object = new CollegeEntities
            {
                Name = collegeObj.Name,
                University = collegeObj.University,
                Address = collegeObj.Address,
                District = collegeObj.District
            };
            var updateData = _collegeDA.UpdateCollege(Object, id);
            return new CollegeModel
            {
                Id = updateData.Id,
                Name = collegeObj.Name,
                University = collegeObj.University,
                Address = collegeObj.Address,
                District = collegeObj.District,
               
            };
        }
    }
}
