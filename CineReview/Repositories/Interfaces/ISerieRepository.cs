using System.Collections.Generic;
using System.Threading.Tasks;
using CineReview.Models;

namespace CineReview.Repositories.Interfaces
{
    public interface ISerieRepository
    {
        Task<IEnumerable<Serie>> GetAllAsync();
        Task<Serie> GetByIdAsync(int id);
        Task AddAsync(Serie serie);
        void Update(Serie serie);
        void Remove(Serie serie);
        Task<bool> SaveChangesAsync();
    }
}
