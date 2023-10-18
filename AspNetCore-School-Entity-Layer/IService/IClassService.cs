using AspNetCore_School_Entity_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.IService
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAll();
        Task<ClassDto> GetById(int id);
    }
}
