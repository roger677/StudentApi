using School.Domain.Entities;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
    }
}