using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetMVC.Data;
using NetMVC.Models;
using Microsoft.AspNetCore.Http;
using NetMVC.Models.Process;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NetMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
       private readonly ExcelProcess _ExcelPro = new ExcelProcess();
        public StudentController(ApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            Configuration = Configuration;
        }
        public IConfiguration Configuration {get;}
        public string ExcelProcessDbContext { get; private set; }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.PStudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PStudentID,StudentName,Address")] Student student,IFormFile file)
        {   

            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                else
                     {
                        //rename file when upload to server
                        //tao duong dan /Uploads/Excels de luu file upload len server
                        var fileName = "Ten file muon luu";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();

                             if (ModelState.IsValid)
                            {
                                //upload file to server
                                if (file.Length > 0)
                                {
                                    using (var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        //save file to server
                                        await file.CopyToAsync(stream);
                                        //read data from file and write to database
                                        //_excelPro la doi tuong xu ly file excel ExcelProcess
                                        var dt = _ExcelPro.ExcelToDataTable(fileLocation);
                                        //ghi du lieu datatable vao database
                                             if (Student.Subject==0) 
                                                 {
                                                    writeInformaticsResults(dt);

                                                 }
                                            else
                                                 {
                                                   writeInformaticsResults(dt);
                                                 }
                                        
                                    }
                                    return RedirectToAction(nameof(Index));
                                    }
                                }
                        }
                  return View(student);      
              }
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
         }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PStudentID,StudentName,Address")] Student student,IFormFile file)
        {   
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                else
                     {
                        //rename file when upload to server
                        //tao duong dan /Uploads/Excels de luu file upload len server
                        var fileName = "Ten file muon luu";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();

                             if (ModelState.IsValid)
                            {
                                //upload file to server
                                if (file.Length > 0)
                                {
                                    using (var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        //save file to server
                                        await file.CopyToAsync(stream);
                                        //read data from file and write to database
                                        //_excelPro la doi tuong xu ly file excel ExcelProcess
                                        var dt = _ExcelPro.ExcelToDataTable(fileLocation);
                                        //ghi du lieu datatable vao database
                                             if (Student.Subject==0) 
                                                 {
                                                    writeInformaticsResults(dt);

                                                 }
                                            else
                                                 {
                                                   writeInformaticsResults(dt);
                                                 }
                                        
                                    }
                                    return RedirectToAction(nameof(Index));
                                    }
                                }
                        }
                  return View(student);      
              }
            if (id != student.PStudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.PStudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.PStudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.PStudentID == id);
        }
        private int writeInformaticsResults(DataTable dt)
        {
            try
            {
                var con = Configuration.GetConnectionString("NetMVCContext");
                SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
                bulkCopy.DestinationTableName = "InformaticsStudentResults";
                bulkCopy.ColumnMappings.Add(1,"PStudentID");
                bulkCopy.ColumnMappings.Add(2,"StudentName");
                bulkCopy.ColumnMappings.Add(3,"Address");
                
            }
            catch{
                return 0;
            }
            return dt.Rows.Count;
        }
        
    }
}
