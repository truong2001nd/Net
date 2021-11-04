using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetMVC.Models
{
    [Table("Students")]
    public class Student{
        [Key]
        public int StudentID { get; set; }
        public int StudentAge { get; set; }
    }

}