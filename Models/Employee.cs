using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NetMVC.Models
{
   [Table("Employee")]
   
    public class Employee
    {
        [Key]
        [DisplayName("Mã số nhân viên")]
        public int EmployeeID  { get; set; }
        
         [DisplayName("Tên nhân viên")]
        public string EmployeeName { get; set; }
        [DisplayName("Số điện thoại")]
        public string  PhoneNumber { get; set; }
       
       
        
    }
}