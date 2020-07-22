using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetExerc2.DAL;
using AspNetExerc2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetExerc2.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {

        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoAPIController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar()
        {
            return Ok(_enderecoDAO.Listar());
        }

        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult Pesquisar(string cep)
        {
            return Ok(_enderecoDAO.Pesquisar(cep));
        }
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastar(Endereco endereco)
        {
            _enderecoDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Alterar(Endereco endereco)
        {
            _enderecoDAO.Alterar(endereco);
            return Ok(endereco);
        }

        [HttpDelete]
        [Route("DeletarEndereco/{cepId}")]
        public IActionResult Alterar(int cepId)
        {
            if (_enderecoDAO.Remover(cepId))
            {
                return Ok(cepId);
            }
            else
            {
                return NotFound();
            }
        }
    }
}