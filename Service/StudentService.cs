using StudentApi.Domain.Entities;
using StudentApi.Infrastructure.Repositories;
using StudentApi.Models;
using StudentApi.Service.Contract;
using StudentApi.Service.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Age = s.Age
            });
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Age = dto.Age
            };

            var result = await _studentRepository.AddAsync(student);

            return new StudentDto
            {
                Id = result.Id,
                FullName = result.FullName,
                Email = result.Email,
                Age = result.Age
            };
        }

        public async Task<StudentDto> UpdateStudentAsync(int id, CreateStudentDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null) return null;

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _studentRepository.UpdateAsync(student);

            return new StudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null) return false;

            await _studentRepository.DeleteAsync(student);
            return true;
        }
    }
}