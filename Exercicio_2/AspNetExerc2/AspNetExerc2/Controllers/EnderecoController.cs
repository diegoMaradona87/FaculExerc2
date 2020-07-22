using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AspNetExerc2.DAL;
using AspNetExerc2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetExerc2.Controllers
{
    public class EnderecoController : Controller
    {
        // Elder Diego Nogozzeky - matricula 1829080 
        
        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
        }
        public Endereco ConsultarCep(string cep)
        {
            string url = $@"https://viacep.com.br/ws/{cep}/json/";
            WebClient cliente = new WebClient();
            string resultado = cliente.DownloadString(url).ToString();
            Endereco endereco = new Endereco();
            if (resultado.Contains("\"erro\": true"))
            {
                return endereco;
            }
            else
            {
                return endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
            }
        }
        public IActionResult Index()
        {
            return View(_enderecoDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult Cadastrar(string txtCep)
        {
            Endereco contem = _enderecoDAO.Pesquisar(txtCep);
            if (contem != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Endereco novoEndereco = ConsultarCep(txtCep);
                if (novoEndereco.Cep == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _enderecoDAO.Cadastrar(novoEndereco);
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
