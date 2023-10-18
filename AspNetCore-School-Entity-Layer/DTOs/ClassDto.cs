using AspNetCore_School_Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.DTOs
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int SchoolId { get; set; }
        public SchoolDto School { get; set; }

        public List<StudentDto> StudentDtos { get; set; }
    }
}
