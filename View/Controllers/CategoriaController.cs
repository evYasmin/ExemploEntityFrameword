using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class CategoriaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Método que permitirá ter acesso aos dados das categorias,
        /// filtrando, ordenando e paginando as informações de acirdi 
        /// com os parametros
        /// </summary>
        /// <param name="buscar"></param>
        /// <param name="quantidade"></param>
        /// <param name="pagina"></param>
        /// <param name="colunaOrdem"></param>
        /// <param name="ordem"></param>
        /// <returns></returns>
        [HttpGet, Route("obtertodos")]
        public IActionResult ObterTodos(
            string buscar = "", int quantidade = 10, int pagina = 0,
            string colunaOrdem = "nome", string ordem = "ASC")
        {
            return Ok();
        }
    }
}