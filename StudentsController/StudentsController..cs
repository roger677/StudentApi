using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.DTOs;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var students = await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    Age = s.Age
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(new StudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
