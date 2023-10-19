namespace AspNetCore_School_Mvc.Models
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int SchoolId { get; set; }
        public SchoolViewModel School { get; set; }

        public List<StudentViewModel> StudentDtos { get; set; }
    }
}
