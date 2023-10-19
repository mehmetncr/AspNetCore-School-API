using AspNetCore_School_Entity_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.IService
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetAll();
        Task<SchoolDto> GetById(int id);
        SchoolDto Add(SchoolDto model);
        string Update(SchoolDto model);
        string Delete(int id);
    }
}
