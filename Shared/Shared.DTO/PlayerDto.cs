using System;

namespace Tournament40.Shared.DTO
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        public Guid TournamentId { get; set; }

        public Guid? AssignedPartnerId { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        
    }
}
