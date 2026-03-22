using StudentApi.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Service.Contract
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<StudentDto> CreateStudentAsync(CreateStudentDto student);
        Task<StudentDto> UpdateStudentAsync(int id, CreateStudentDto student);
        Task<bool> DeleteStudentAsync(int id);
    }
}