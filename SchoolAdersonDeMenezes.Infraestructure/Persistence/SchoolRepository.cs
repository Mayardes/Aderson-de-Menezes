using MongoDB.Driver;
using SchoolAdersonDeMenezes.Domain.Entities;
using SchoolAdersonDeMenezes.Domain.Repositories;

namespace SchoolAdersonDeMenezes.Infraestructure.Persistence
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly IMongoCollection<School> _collection;
        public SchoolRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<School>("schools");
        }
        public async Task<Guid> AddAsync(School school)
        {
            await _collection.InsertOneAsync(school);

            return school.Id;
        }

        public async Task<School> GetByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            
        }

        public async Task<School> UpdateAsync(School school)
        {
            await _collection.ReplaceOneAsync(x => x.Id == school.Id, school);
            return school;
        }
    }
}
