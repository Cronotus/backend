﻿namespace Shared.DataTransferObjects
{
    public record ProfileForReturnDto
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? ProfilePicture { get; init; }
        public string? ProfileCoverImage { get; init; }
    }
}
