using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Application.Notes.Queries.GetNoteDetails;
using Server.Domain;

namespace Server.Application.User.Queries.GetAccountDetails
{
    public class AccountDetailsVm : IMapWith<Account>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountDetailsVm>()
            .ForMember(noteVm => noteVm.Username,
                opt => opt.MapFrom(note => note.Username))
            .ForMember(noteVm => noteVm.Password,
                opt => opt.MapFrom(note => note.Password))
            .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
            .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(note => note.CreationDate));
        }
    }
}
