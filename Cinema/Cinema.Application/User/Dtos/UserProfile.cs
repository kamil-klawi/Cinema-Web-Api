using AutoMapper;
using Cinema.Application.User.Commands.CreateUser;
using Cinema.Application.User.Commands.UpdateUser;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Dtos;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UpdateUserCommand, CinemaEntities.User>();

        CreateMap<CreateUserCommand, CinemaEntities.Cinema>();
        
        CreateMap<CinemaEntities.User, UserDto>()
            .ForMember(u => u.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        
        CreateMap<UserDto, CinemaEntities.User>()
            .ForMember(u => u.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(u => u.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email));
    }
}