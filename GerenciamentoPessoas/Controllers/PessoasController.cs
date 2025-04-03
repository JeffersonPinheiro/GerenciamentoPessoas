using GerenciamentoPessoas.Data;
using GerenciamentoPessoas.Entities;
using GerenciamentoPessoas.Models;
using GerenciamentoPessoas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("ListarPessoas")]
        public async Task<ActionResult<List<PessoaDto>>> ListarPessoas([FromQuery] bool? apenasIdosos = null)
        {
            var pessoasDto = await _pessoaService.ListarPessoasAsync(apenasIdosos);
            return Ok(pessoasDto);
        }

        [HttpGet("BuscarPessoaPorId")]
        public async Task<ActionResult<PessoaDto>> BuscarPessoa(int id)
        {
            var pessoaDto = await _pessoaService.BuscarPessoaPorIdAsync(id);
            if (pessoaDto is null)
            {
                return NotFound();
            }
            return Ok(pessoaDto);
        }

        [HttpPost("AdicionarPessoa")]
        public async Task<ActionResult<PessoaDto>> AdicionarPessoa(PessoaDto novaPessoaDto)
        {
            if (novaPessoaDto == null)
            {
                return BadRequest();
            }

            var pessoaAdicionadaDto = await _pessoaService.AdicionarPessoaAsync(novaPessoaDto);
            return CreatedAtAction(nameof(BuscarPessoa), new { id = pessoaAdicionadaDto.Id }, pessoaAdicionadaDto);
        }

        [HttpPut("AtualizarPessoa/{id}")]
        public async Task<IActionResult> AtualizarPessoa(int id, PessoaDto pessoaDto)
        {
            var resultado = await _pessoaService.AtualizarPessoaAsync(id, pessoaDto);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("DeletarPessoa/{id}")]
        public async Task<IActionResult> DeletarPessoa(int id)
        {
            var resultado = await _pessoaService.DeletarPessoaAsync(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
