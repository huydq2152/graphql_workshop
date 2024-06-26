﻿using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Data.Speakers;

[ExtendObjectType("Query")]
public class SpeakerQueries
{
    [UsePaging]
    public Task<IQueryable<Speaker>> GetPagedSpeakersAsync(
        ApplicationDbContext context) =>
        Task.FromResult<IQueryable<Speaker>>(context.Speakers.OrderBy(t => t.Name));
    
    public Task<List<Speaker>> GetSpeakersAsync(ApplicationDbContext context) =>
        context.Speakers.ToListAsync();
    
    public async Task<Speaker> GetSpeakerByIdAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        await dataLoader.LoadAsync(id, cancellationToken);
    
    public async Task<IEnumerable<Speaker>> GetSpeakersByIdsAsync(
        [ID(nameof(Speaker))]int[] ids,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        await dataLoader.LoadAsync(ids, cancellationToken);
}