

using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.Entities;
using AspNetCore_School_Entity_Layer.IService;
using AspNetCore_School_Entity_Layer.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAll(int id)
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _unitOfWork.GetRepository<Student>().GetAll(x=>x.ClassId==id,null,x=>x.Class));
        }
    }
}
