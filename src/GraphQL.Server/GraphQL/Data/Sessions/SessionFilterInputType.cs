﻿using GraphQL.Server.Data.Entities;
using HotChocolate.Data.Filters;

namespace GraphQL.Server.GraphQL.Data.Sessions;

public class SessionFilterInputType: FilterInputType<Session>
{
    protected override void Configure(IFilterInputTypeDescriptor<Session> descriptor)
    {
        descriptor.Ignore(t => t.Id);
        descriptor.Ignore(t => t.TrackId);
    }
}