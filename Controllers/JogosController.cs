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
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogos = _jogoRepository.Listar();

                if (jogos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = jogos.Count,
                    data = jogos
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
                Jogo jogo = _jogoRepository.BuscarID(id);

                if (jogo == null)
                    return NotFound();

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Jogo jogo)
        {
            try
            {
                _jogoRepository.Adicionar(jogo);

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                var jogoTemp = _jogoRepository.BuscarID(id);

                if (jogo == null)
                    return NotFound();

                jogo.Id = id;
                _jogoRepository.Editar(jogo);

                return Ok(jogo);
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
                _jogoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
