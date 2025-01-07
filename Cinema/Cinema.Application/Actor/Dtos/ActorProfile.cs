using AutoMapper;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Actor.Dtos;

public class ActorProfile : Profile
{
    public ActorProfile()
    {
        CreateMap<ActorDto, CinemaEntities.Actor>();
        CreateMap<CinemaEntities.Actor, ActorDto>();
    }
}