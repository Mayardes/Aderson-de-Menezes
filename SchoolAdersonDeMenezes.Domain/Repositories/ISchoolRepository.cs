using SchoolAdersonDeMenezes.Domain.Entities;

namespace SchoolAdersonDeMenezes.Domain.Repositories
{
    public interface ISchoolRepository
    {
        Task<Guid> AddAsync(School school);
        Task<School> GetByIdAsync(Guid id);
        Task<School> UpdateAsync(School school);
    }
}
