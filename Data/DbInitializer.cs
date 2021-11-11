using System;
using System.Collections.Generic;
using System.Linq;
using NetMVC.Models;

namespace NetMVC.Data
{

    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            var date = new DateTime(2021, 3, 20, 5, 21, 32);

            // if (_context.Person.Any())
            // {
            //     return;
            // }
            // if (_context.Movie.Any())
            // {
            //     return;
            // }
            // if (_context.Student.Any())
            // {
            //     return;
            // }
            // if (_context.Employee.Any())
            // {
            //     return;
            // }

            var listPerson = new List<Person>()
            {
                new Person(){PersonID ="ID1",PersonName ="Join"},
                 new Person(){PersonID ="ID2",PersonName ="Rolnaldo"},
                  new Person(){PersonID ="ID3",PersonName ="Messi"},
                   new Person(){PersonID ="ID4",PersonName ="Roorey"},
                    new Person(){PersonID ="ID5",PersonName ="ChienPham"}
            };

            var listEmployee = new List<Employee>()
            {
                new Employee(){EmployeeID=1,EmployeeName="Employee1",PhoneNumber="03947392937"},
                  new Employee(){EmployeeID=2,EmployeeName="Employee2",PhoneNumber="0394222937"},
                    new Employee(){EmployeeID=3,EmployeeName="Employee3",PhoneNumber="03947772937"},
                      new Employee(){EmployeeID=4,EmployeeName="Employee4",PhoneNumber="03949992937"},
                        new Employee(){EmployeeID=5,EmployeeName="Employee5",PhoneNumber="03941192937"},
            };
            var listStudent = new List<Student>()
            { 
                 new Student(){PStudentID=1,StudentName="Truong",Address="Nam Định"},
                 new Student(){PStudentID=2,StudentName="luat",Address="Nam Trực"},
                 new Student(){PStudentID=3,StudentName="Minh",Address="Bình Minh"},
                 new Student(){PStudentID=4,StudentName="Hieu",Address="Ha Nội"},
                 new Student(){PStudentID=5,StudentName="Long",Address="Hải Dương"},
            };
            var listProduct = new List<Product>()
            {
                new Product(){ ProductID=1,ProductName="Giày",UnitPrice= 1500000, Quantity=20},
                new Product(){ ProductID=5,ProductName="Quần",UnitPrice= 1600000, Quantity=29},
                new Product(){ ProductID=6,ProductName="Áo",UnitPrice= 1700000, Quantity=27},
                new Product(){ ProductID=7,ProductName="Mũ",UnitPrice= 1800000, Quantity=25},
                new Product(){ ProductID=8,ProductName="Váy",UnitPrice= 1900000, Quantity=21},
            };
            _context.Person.AddRange(listPerson);
            _context.Employee.AddRange(listEmployee);
            _context.Student.AddRange(listStudent);
            _context.Product.AddRange(listProduct);



            _context.SaveChanges();

        }

    }
}