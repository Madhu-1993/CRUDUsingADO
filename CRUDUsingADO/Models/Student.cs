using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Rollno { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public int Fees { get; set; }
    }
}
