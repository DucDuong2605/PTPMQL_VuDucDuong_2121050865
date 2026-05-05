using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
     public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

    // ================= READ =================
        public IActionResult Index()
        {
            var data = _context.Students 
                .Select(s => new StudentFacultyViewModel
                {
                    StudentID = s.StudentID,
                    FullName = s.FullName,
                    FacultyName = s.Faculty!.FacultyName
                })
                .ToList();

            return View(data);
        }

    // ================= CREATE =================
        public IActionResult Create()
        {
            ViewBag.Faculties = _context.Faculties.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faculties = _context.Faculties.ToList();
            return View(student);
        }

    // ================= UPDATE =================
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            ViewBag.Faculties = _context.Faculties.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faculties = _context.Faculties.ToList();
            return View(student);
        }

    // ================= DELETE =================
        public IActionResult Delete(int id)
        {
            var student = _context.Students
                .Where(s => s.StudentID == id)
                .Select(s => new StudentFacultyViewModel
                {
                    StudentID = s.StudentID,
                    FullName = s.FullName,
                    FacultyName = s.Faculty!.FacultyName
                })
                .FirstOrDefault();

            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ");
            }

            var students = new List<Student>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // bỏ header
                    {
                        var student = new Student
                        {
                            Name = worksheet.Cells[row, 1].Text,
                            Email = worksheet.Cells[row, 2].Text,
                            Age = int.Parse(worksheet.Cells[row, 3].Text)
                        };

                        students.Add(student);
                    }
                }
            }

            await _context.Students.AddRangeAsync(students);
            await _context.SaveChangesAsync();

            return Ok("Import thành công!");
        }
    }
}
