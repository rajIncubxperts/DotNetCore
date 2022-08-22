using Microsoft.EntityFrameworkCore;
using RestFulApi_Repo.Data;
using RestFulApi_Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulApi_Repo.DataAccessLayer
{
    public interface ICollegeDAL
    {
        IEnumerable<CollegeEntities> GetCollege();
         CollegeEntities GetStudent(int Id);

       Task <CollegeEntities> AddCollegeDetails(CollegeEntities collegeObj);

        CollegeEntities DeleteCollege(int Id);

        CollegeEntities UpdateCollege(CollegeEntities collegeObj, int Id);

    }
    public class CollegeImplantationDAL : ICollegeDAL
    {
        private readonly ApplicationDbContext _Context;

        public CollegeImplantationDAL(ApplicationDbContext Context)
        {
            _Context = Context;       // with Dependency Injection
        }

        public async Task<CollegeEntities> AddCollegeDetails(CollegeEntities collegeObj)
        {
            var res =await  _Context.Collages.AddAsync(collegeObj);
            _Context.SaveChanges();
            return res.Entity;
        }

        public CollegeEntities DeleteCollege(int Id)
        {
           var res = _Context.Collages.FirstOrDefault(s => s.Id == Id);
            if (res != null)
            {
                _Context.Collages.Remove(res);
                _Context.SaveChanges();
                return res;
                             
            }
            return null;
        }

        public IEnumerable<CollegeEntities> GetCollege()
        {
            return _Context.Collages.ToList();
        }

        public CollegeEntities GetStudent(int Id)
        {
               
            return _Context.Collages.FirstOrDefault(s => s.Id == Id);
        }

        public CollegeEntities UpdateCollege(CollegeEntities collegeObj, int Id)
        {
            var updatedata = _Context.Collages.Where(s => s.Id == Id).ToList();
            foreach (var item in updatedata)
            {
                if (item.Id == Id)
                {
                    item.Name = collegeObj.Name;
                    item.University = collegeObj.University;
                    item.Address = collegeObj.Address;
                    item.District = collegeObj.District;
                    var update = _Context.Collages.Update(item);
                    _Context.SaveChanges();
                    return update.Entity;
                }
                }
                return collegeObj; 
            }
        }
    }
