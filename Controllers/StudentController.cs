using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIApplication.Models;

namespace APIApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // URL Base: api/student
    public class StudentController : ControllerBase
    {
        // បញ្ជីសិស្សសិប្បនិម្មិតក្នុង memory
        private static List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Dara SOK", Major = "Computer Science", DOB = new DateTime(2000, 1, 1), Email = "dara.sok@example.com", Telegram = "@dara_sok" },
            new Student { Id = 2, Name = "Cheata SENG", Major = "Information Technology", DOB = new DateTime(2001, 2, 2), Email = "cheata.seng@example.com", Telegram = "@cheata_seng" },
            new Student { Id = 3, Name = "Sopheap CHHAY", Major = "Software Engineering", DOB = new DateTime(2002, 3, 3), Email = "sopheap.chhay@example.com", Telegram = "@sopheap_chhay" },
            new Student { Id = 4, Name = "Rithy KIM", Major = "Data Science", DOB = new DateTime(2003, 4, 4), Email = "rithy.kim@example.com", Telegram = "@rithy_kim" },
            new Student { Id = 5, Name = "Sreyneang HENG", Major = "Cybersecurity", DOB = new DateTime(2004, 5, 5), Email = "sreyneang.heng@example.com", Telegram = "@sreyneang_heng" }
        };

        // ១. GET: api/student (ទាញយកសិស្សទាំងអស់)
        [HttpGet]
        //public IActionResult GetAll() => Ok(_students);
        public IActionResult GetAll()
        {
            if (_students.Count == 0)
                return NotFound("មិនមានសិស្សនៅក្នុងបញ្ជីទេ");
            return Ok(_students);
        }

        // ២. GET: api/student/1 (ទាញយកតាម ID)
        [HttpGet("{id}")] //Route Attribute and Parameter Binding
        public IActionResult GetById(int id)
        {
            var student = _students.Find(X => X.Id == id);
            if (student == null) 
                return NotFound($"រកមិនឃើញសិស្សដែលមាន ID = {id}");
            return Ok(student);
        }
    }
}