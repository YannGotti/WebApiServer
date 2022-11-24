using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Domain;


namespace Server.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(note => note.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(note => note.Title,
                    opt => opt.MapFrom(note => note.Title));
        }

    }
}
