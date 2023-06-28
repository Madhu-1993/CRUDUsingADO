using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class prod
    {
        [Key]
        [ScaffoldColumn(false)]//to define id is pk in db table
        public int p_id { get; set; }
        [Required]
        public string p_name { get; set; }
        [Required]
        public string company { get; set; }
        [Required]
        public int price { get; set; }

    }
}
