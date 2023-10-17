using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int SchoolId { get; set; }
        public School School { get; set; }

        public List<Student> Students { get; set; }
    }
}
