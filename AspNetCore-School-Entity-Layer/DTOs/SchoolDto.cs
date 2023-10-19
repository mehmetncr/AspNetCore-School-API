using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore_School_Entity_Layer.Entities;

namespace AspNetCore_School_Entity_Layer.DTOs
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }

        public List<ClassDto>? Classes { get; set; }
    }
}
