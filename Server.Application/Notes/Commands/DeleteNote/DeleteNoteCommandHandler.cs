﻿using MediatR;
using Server.Application.Interfaces;
using Server.Application.Common.Exeptions;
using Server.Domain;

namespace Server.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler
        : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
