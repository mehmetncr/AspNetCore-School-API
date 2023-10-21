using AspNetCore_School_Entity_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.IService
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAll(int id);
        StudentDto Add(StudentDto model);
        StudentDto GetById(int id);
        string Delete(int id);
        string Update(StudentDto model);
    }
}
