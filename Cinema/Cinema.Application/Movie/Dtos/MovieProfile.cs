using AutoMapper;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Movie.Dtos;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieDto, CinemaEntities.Movie>();
        CreateMap<CinemaEntities.Movie, MovieDto>()
            .ForMember(m => m.Actors, opt => opt.MapFrom(src => src.Actors))
            .ForMember(m => m.Director, opt => opt.MapFrom(src => src.Director));
    }
}