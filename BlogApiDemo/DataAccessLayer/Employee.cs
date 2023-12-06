using System.ComponentModel.DataAnnotations;

namespace BlogApiDemo.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public String? Name { get; set; }
    }
}
