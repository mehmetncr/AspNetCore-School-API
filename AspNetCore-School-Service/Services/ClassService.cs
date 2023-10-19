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
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ClassDto Add(ClassDto model)
        {
            try
            {
                _unitOfWork.GetRepository<Class>().Add(_mapper.Map<Class>(model));
                _unitOfWork.Commit();
                return model;
            }
            catch (Exception)
            {

                return new ClassDto();
            }
           
        }

        public async Task<IEnumerable<ClassDto>> GetAll(int id)
        {
            return _mapper.Map<IEnumerable<ClassDto>>(await _unitOfWork.GetRepository<Class>().GetAll(x=>x.SchoolId==id,null,x=>x.School));
        }

        public ClassDto GetById(int id)
        {
            return _mapper.Map<ClassDto>(_unitOfWork.GetRepository<Class>().GetById(id));
        }
    }
}
