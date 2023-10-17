using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }

        public List<Class> Classes { get; set; }
    }
}
