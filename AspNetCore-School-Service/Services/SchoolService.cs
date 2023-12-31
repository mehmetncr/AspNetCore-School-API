﻿using AspNetCore_School_Entity_Layer.DTOs;
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
    public class SchoolService : ISchoolService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public SchoolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SchoolDto Add(SchoolDto model)
        {
            try
            {
                _unitOfWork.GetRepository<School>().Add(_mapper.Map<School>(model));
                _unitOfWork.Commit();
                return model;
            }
            catch (Exception)
            {

                return new SchoolDto();
            }
          
           
        }

        public string Delete(int id)
        {
            try
            {
                _unitOfWork.GetRepository<School>().Delete(id);
                _unitOfWork.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {

                return  ex.Message;
            }
        }

        public async Task<IEnumerable<SchoolDto>> GetAll()
        {
           return _mapper.Map<IEnumerable<SchoolDto>>( await _unitOfWork.GetRepository<School>().GetAllAsync());
        }

        public async Task<SchoolDto> GetById(int id)
        {
            return _mapper.Map<SchoolDto>(await _unitOfWork.GetRepository<School>().GetByIdAsync(id));
        }

        public string Update(SchoolDto model)
        {
            try
            {
                _unitOfWork.GetRepository<School>().Update(_mapper.Map<School>(model));
                _unitOfWork.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
          
        }
    }
}
