using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Repositories;
using Xunit;

namespace APILivroTeste
{
    public class LivrosControllerTest
    {
        LivrosController _controller;
        ILivroRepository _repository;

        public LivrosControllerTest()
        {
            _repository = new LivroRepositoryFake();
            _controller = new LivrosController(_repository);       
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = (ObjectResult)_controller.ListarLivros() ;
            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = (ObjectResult)_controller.ListarLivros();
            // Assert
            var items = Assert.IsType<List<Livro>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Post_WhenCalled_Adiciona_Livro()
        {
            var livro = new Livro()
            {
                Id = 4,
                name = "3 porquinhos",
                price = 1.5,
                Specifications = new Specifications()
                {
                    author = "Sem informações",
                    genres = "Não sei",
                    illustrator = "Não sei",
                    originallypublished = new DateTime(),
                    pageCount = 200,
                }

            };
            // Act
            var okResult = (ObjectResult)_controller.AdicionarLivro(livro);
            var okResultConsulta = (ObjectResult)_controller.ListarLivros();
            // Assert
            var items = Assert.IsType<List<Livro>>(okResultConsulta.Value);
            
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_sortByPrice()
        {
            // Act
            var okResult = (ObjectResult)_controller.sortByPrice();
            // Assert
            var items = Assert.IsType<List<Livro>>(okResult.Value);
            Assert.Equal("Pequeno Principe", items[0].name);
            Assert.Equal("Boruto", items[1].name);
            Assert.Equal("Naruto", items[2].name);
        }
        [Fact]
        public void Get_WhenCalled_sortByPriceAscendent()
        {
            // Act
            var okResult = (ObjectResult)_controller.sortByPriceAscendent();
            // Assert
            var items = Assert.IsType<List<Livro>>(okResult.Value);
            Assert.Equal("Naruto", items[0].name);
            Assert.Equal("Boruto", items[1].name);
            Assert.Equal("Pequeno Principe", items[2].name);
        }

        [Theory]
        [InlineData(0, "Não sei", 1)]
        [InlineData(1, "Naruto", 1)]
        [InlineData(0, "QUALQUERCOISA", 0)]
        [InlineData(1, "QUALQUERCOISA", 0)]

        public void Get_WhenCalled_filterByValue(int type, string value, int count)
        {
            // Act
            var okResult = (ObjectResult)_controller.filterByValue(type, value);
            // Assert
            var items = Assert.IsType<List<Livro>>(okResult.Value);
            Assert.Equal(count, items.Count);

        }

        [Theory]
        [InlineData(1)]
        public void Get_WhenCalled_livroFrete(int Id)
        {
            // Act
            var okResult = (ObjectResult)_controller.livroFrete(Id);
            // Assert
            var items = Assert.IsType<List<Livro>>(okResult.Value);
            Assert.Equal("Pequeno Principe", items[0].name);

        }
    }
}
