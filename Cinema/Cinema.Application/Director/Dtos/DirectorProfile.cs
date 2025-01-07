using AutoMapper;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Director.Dtos;

public class DirectorProfile : Profile
{
    public DirectorProfile()
    {
        CreateMap<DirectorDto, CinemaEntities.Director>();
        CreateMap<CinemaEntities.Director, DirectorDto>();
    }
}