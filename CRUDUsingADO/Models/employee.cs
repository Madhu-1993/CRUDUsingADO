using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Eid { get; set; }
        [Required]
        public string Ename { get; set; }
        [Required]
        public string Dept { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
