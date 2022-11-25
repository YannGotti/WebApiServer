using AutoMapper;
using Server.Application.Common.Mappings;
using Server.Application.Notes.Commands.CreateNote;
using Server.Application.Notes.Commands.UpdateNote;

namespace Server.WebApiNet7.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                        opt => opt.MapFrom(noteDto => noteDto.Details));
        }

    }
}
