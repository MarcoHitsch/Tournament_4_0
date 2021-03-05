using System;
using System.Collections.Generic;

namespace Tournament40.Shared.DTO
{
    public class TournamentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<PlayerDto> Players { get; set; }
    }
}
