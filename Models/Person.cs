using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NetMVC.Models
{
   [Table("Person")]
   
    public class Person
    {
        [Key]
        [DisplayName("Người thứ")]
        public string PersonID  { get; set; }
        
         [DisplayName("Tên")]
        public string PersonName { get; set; }
       
       
        
    }
}