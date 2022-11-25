using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Domain;

namespace Server.Application.Accounts.Queries.GetAccountList
{
    public class AccountLookupDto : IMapWith<Account>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountLookupDto>()
                .ForMember(note => note.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(note => note.Username,
                    opt => opt.MapFrom(note => note.Username));
        }
    }
}
