using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SchoolNo { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
