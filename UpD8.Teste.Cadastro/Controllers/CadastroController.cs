
using Microsoft.AspNetCore.Mvc;

using UpD8.Teste.Cadastro.Models;
using UpD8.Teste.Cadastro.Services;

namespace UpD8.Teste.Cadastro.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IClienteServices iClienteServices;
        public CadastroController(IClienteServices iClienteServices)
        {
            this.iClienteServices = iClienteServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pesquisa()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(Cliente cliente)
        {
            try
            {
                var result = iClienteServices.Get(cliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var result = iClienteServices.GetbyId(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Cliente cliente)
        {
            try
            {
                iClienteServices.Add(cliente);
                return Ok("Cadastro com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Cliente cliente)
        {
            try
            {
                iClienteServices.Update(cliente);
                return Ok("Alterado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                iClienteServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
