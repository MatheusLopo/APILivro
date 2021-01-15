using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Enums;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    public class LivrosController : Controller
    {
        private readonly ILivroRepository _repositorio;

        public LivrosController(ILivroRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("livros")]
        public IActionResult ListarLivros()
        {
            return Ok(_repositorio.ListarLivros());
        }

        [HttpPost("v1/livros")]
        public IActionResult AdicionarLivro([FromBody] Livro livro)
        {

            _repositorio.Adicionar(livro);
            return Ok("O livro foi adicionado");
        }

        [HttpGet("livros/descending")]
        public IActionResult sortByPrice()
        {
            return Ok(_repositorio.sortByPrice());
        }

        [HttpGet("livros/ascendent")]
        public IActionResult sortByPriceAscendent()
        {
            return Ok(_repositorio.sortByPriceAscendent());
        }

        [HttpGet("livro/{filterType}/{value}")]

        public IActionResult filterByValue([FromHeader] int? filterType, [FromHeader] string value)
        {
            if (value == null || filterType == null)
            {
                return BadRequest();
            }

            var type = Convert(filterType.Value);
            
            if (type == EnumFilterType.AUTHOR)
            {
                return Ok(_repositorio.filterByAuthor(value));
            } else if (type == EnumFilterType.BOOK_NAME)
            {
                return Ok(_repositorio.filterByName(value));
            }

            return NotFound();


        }

        [HttpGet("livro/frete/{Id}")]
        public IActionResult livroFrete([FromHeader] int Id)
        {
            if(Id != 0)
            {
                return Ok(_repositorio.livroFrete(Id));
            }
            return NotFound();
        }




        private EnumFilterType? Convert (int value)
        {
            object convertedValue;
            if (Enum.TryParse(typeof(EnumFilterType), value.ToString(), out convertedValue))
            {
                return (EnumFilterType)convertedValue;
            }
            return null;
        }
        private int Convert(string value) 
        {
            int convertedValue = 0;
            if (int.TryParse(value, out convertedValue))
            {
                return convertedValue;
            }
            return convertedValue;
        }
        




    }

}
