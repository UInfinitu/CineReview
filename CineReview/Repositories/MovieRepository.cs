using CineReview.Data;
using CineReview.Models;
using CineReview.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineReview.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataBaseContext _ctx;
        public MovieRepository(DataBaseContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Movie>> GetAllAsync()
            => await _ctx.Movies.ToListAsync();

        public async Task<Movie> GetByIdAsync(int id)
            => await _ctx.Movies.FindAsync(id);

        public async Task AddAsync(Movie movie) => await _ctx.Movies.AddAsync(movie);

        public void Update(Movie movie) => _ctx.Movies.Update(movie);

        public void Remove(Movie movie) => _ctx.Movies.Remove(movie);

        public async Task<bool> SaveChangesAsync() => (await _ctx.SaveChangesAsync()) > 0;
    }
}

