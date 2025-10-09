using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Users.Commands.CreateUser;
using Tasks.Application.Users.Commands.LogingUsrt;

namespace Tasks.WebApi.Models.Users
{
    public class LoginUserDto : IMapWith<LoginUserCommand>
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(UserCommand => UserCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(UserCommand => UserCommand.Password,
                    opt => opt.MapFrom(userDto => userDto.Password));
        }
    }
}
