﻿using System.ComponentModel.DataAnnotations;
using GraphQL.GraphQL.Extensions;

namespace GraphQL.Data.Entities;

public class Track
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    [UseUpperCase]
    public string? Name { get; set; }

    public ICollection<Session> Sessions { get; set; } = 
        new List<Session>();
}