using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateCinema;
using Cinema.Application.Cinema.Commands.UpdateCinema;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Cinema.Dtos;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<UpdateCinemaCommand, CinemaEntities.Cinema>();
        
        CreateMap<CreateCinemaCommand, CinemaEntities.Cinema>()
            .ForMember(c => c.Address, opt => opt.MapFrom(src => new CinemaEntities.Address()
            {
                State = src.State,
                City = src.City,
                Street = src.Street,
                ZipCode = src.ZipCode,
            }));
        
        CreateMap<CinemaDto, CinemaEntities.Cinema>()
            .ForMember(c => c.Address, opt => opt.MapFrom(src => new CinemaEntities.Address()
            {
                State = src.State,
                City = src.City,
                Street = src.Street,
                ZipCode = src.ZipCode,
            }));
        
        CreateMap<CinemaEntities.Cinema, CinemaDto>()
            .ForMember(c => c.State, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.State))
            .ForMember(c => c.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(c => c.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(c => c.ZipCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.ZipCode))
            .ForMember(c => c.Movies, opt => opt.MapFrom(src => src.Movies));
    }
}