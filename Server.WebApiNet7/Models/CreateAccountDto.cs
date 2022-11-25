using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Application.User.Commands.CreateAccount;

namespace Server.WebApiNet7.Models
{
    public class CreateAccountDto : IMapWith<CreateAccountCommand>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAccountDto, CreateAccountCommand>()
                .ForMember(noteCommand => noteCommand.Username,
                    opt => opt.MapFrom(noteDto => noteDto.Username))
                .ForMember(noteCommand => noteCommand.Email,
                    opt => opt.MapFrom(noteDto => noteDto.Email))
                .ForMember(noteCommand => noteCommand.Password,
                    opt => opt.MapFrom(noteDto => noteDto.Password));
        }
    }
}
