using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CineReview.Data;
using CineReview.Models;
using CineReview.Repositories.Interfaces;

namespace CineReview.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly DataBaseContext _ctx;
        public SerieRepository(DataBaseContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Serie>> GetAllAsync()
            => await _ctx.Series.ToListAsync();

        public async Task<Serie> GetByIdAsync(int id)
            => await _ctx.Series.FindAsync(id);

        public async Task AddAsync(Serie serie) => await _ctx.Series.AddAsync(serie);

        public void Update(Serie serie) => _ctx.Series.Update(serie);

        public void Remove(Serie serie) => _ctx.Series.Remove(serie);

        public async Task<bool> SaveChangesAsync() => (await _ctx.SaveChangesAsync()) > 0;
    }
}

