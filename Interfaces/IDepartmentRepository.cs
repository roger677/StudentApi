using School.Domain.Entities;

namespace School.Infrastructure.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
    }
}