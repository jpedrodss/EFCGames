using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCGames.Domains;
using EFCGames.Interfaces;
using EFCGames.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadoresController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogadores = _jogadorRepository.Listar();

                if (jogadores.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = jogadores.Count,
                    data = jogadores
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para nós, informando o problema ocorrido no endpoint Get/Jogos. email@email.com."
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Jogador jogador = _jogadorRepository.BuscarID(id);

                if (jogador == null)
                    return NotFound();

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Jogador jogador)
        {
            try
            {
                _jogadorRepository.Adicionar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Jogador jogador)
        {
            try
            {
                var jogadorTemp = _jogadorRepository.BuscarID(id);

                if (jogador == null)
                    return NotFound();

                jogador.Id = id;
                _jogadorRepository.Editar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogadorRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
