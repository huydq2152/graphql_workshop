﻿using System.Reflection;
using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using HotChocolate.Types.Descriptors;

namespace GraphQL.Server.GraphQL.Extensions;

public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
{
    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.UseDbContext<ApplicationDbContext>();
    }
}