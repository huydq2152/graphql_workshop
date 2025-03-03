﻿namespace GraphQL.Server.GraphQL.Data.Attendees.Register;

public record RegisterAttendeeInput(
    string FirstName,
    string LastName,
    string UserName,
    string EmailAddress);