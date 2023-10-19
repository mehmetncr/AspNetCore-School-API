namespace AspNetCore_School_Mvc.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SchoolNo { get; set; }

        public int ClassId { get; set; }
        public ClassViewModel Class { get; set; }
    }
}
