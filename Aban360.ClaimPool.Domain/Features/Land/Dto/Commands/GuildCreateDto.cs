﻿namespace Aban360.ClaimPool.Domain.Features.Land.Dto.Commands
{
    public record GuildCreateDto
    {
        public short Id { get; set; }
        public short UsageId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
