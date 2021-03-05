using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournament40.Service.DAL.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Guid? AssignedPartnerId { get; set; }

        [ForeignKey(nameof(AssignedPartnerId))]
        public Player AssignedPartner { get; set; }

        public Guid TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        public Tournament Tournament { get; set; }
        
        /* 
         * for possible later use when skill levels and games are implemented
        public ISkillLevel SkillLevel { get; set; }
        public ICollection<IGame> Games { get; set; }
        */

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreationDate { get; set; }
    }
}
