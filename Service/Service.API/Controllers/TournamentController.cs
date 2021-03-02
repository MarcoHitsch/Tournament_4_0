using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament40.Service.BLL.Tournaments;
using Tournament40.Shared.DTO;

namespace Tournament40.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<List<TournamentDto>> GetAll()
        {
            return await tournamentService.GetAllTournaments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetById(Guid id)
        {
            var tournament = await tournamentService.GetTournamentById(id);
            
            if (tournament == null) 
                return this.NotFound();

            return tournament;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TournamentDto inputTournament)
        {
            inputTournament.Id = Guid.NewGuid();
            await tournamentService.AddNewTournament(inputTournament);

            return this.CreatedAtAction(nameof(GetById), new { id = inputTournament.Id }, inputTournament);
        }
    }
}
