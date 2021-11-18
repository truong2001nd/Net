using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NetMVC.Models
{
   [Table("Product")]
   
    public class Product
    {
        [Key]
        [DisplayName("Mã số Sảm phẩm")]
        public int ProductID  { get; set; }
        
         [DisplayName("Tên sảm phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Giá đơn vị")]
        public int  UnitPrice { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Category Category {get; set;}

       
       
        
    }
}