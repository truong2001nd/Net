using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NetMVC.Models
{
   [Table("Student")]
   
    public class Student 
    {
        public static int Subject { get; internal set; }
        [Key]
        [DisplayName("Mã số Sinh viên")]
        public int PStudentID  { get; set; }
        
         [DisplayName("Tên sinh viên")]
        public string StudentName { get; set; }
        [DisplayName("Địa chỉ")]
        public string  Address { get; set; }
       
       
        
    }
}