using AutoMapper;
using CineReview.DTOs;
using CineReview.Models;


namespace CineReview.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<Movie, MovieReadDto>();

            CreateMap<ReviewCreateDto, Review>();
            CreateMap<Review, ReviewReadDto>();

            CreateMap<SerieCreateDto, Serie>();
            CreateMap<Serie, SerieReadDto>();

            // Series / Season / Episode mappings if needed
        }
    }
}

