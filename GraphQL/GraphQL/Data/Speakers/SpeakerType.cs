﻿using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Data.Speakers;

public class SpeakerType : ObjectType<Speaker>
{
    protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) => ctx.DataLoader<SpeakerByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        
        descriptor
            .Field(t => t.SessionSpeakers)
            .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
            .Name("sessions");
    }

    private class SpeakerResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            Speaker speaker,
            ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] sessionIds = await dbContext.Speakers
                .Where(s => s.Id == speaker.Id)
                .Include(s => s.SessionSpeakers)
                .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                .ToArrayAsync(cancellationToken);

            return await sessionById.LoadAsync(sessionIds, cancellationToken);
        }
    }
}