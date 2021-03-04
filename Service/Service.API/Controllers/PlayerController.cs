using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournament40.Service.BLL.Players;
using Tournament40.Shared.DTO;

namespace Tournament40.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<List<PlayerDto>> GetAll()
        {
            return await playerService.GetAllPlayers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById(Guid id)
        {
            var player = await playerService.GetPlayerById(id);

            if (player == null)
                return this.NotFound();

            return player;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlayerDto inputPlayer)
        {
            inputPlayer.Id = Guid.NewGuid();
            await playerService.AddNewPlayer(inputPlayer);

            return this.CreatedAtAction(nameof(GetById), new { id = inputPlayer.Id }, inputPlayer);
        }
    }
}
