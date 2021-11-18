using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NetMVC.Models
{
   
   
    public class People : Person
    {
        
        public int PeopleID  { get; set; }
        
         
        public string PeopleName { get; set; }
        public int Age { get; set; }
       
       
        
    }
}