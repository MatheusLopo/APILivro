using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace APILivroTeste
{
    class LivroRepositoryFake : ILivroRepository
    {
        private readonly List<Livro> _storage;

        public LivroRepositoryFake()
        {
            _storage = new List<Livro>();
            var livro1 = new Livro()
            {
                Id = 1,
                name = "Pequeno Principe",
                price = 10.00,
                Specifications = new Specifications()
                {
                    author = "Não sei",
                    genres = "Não sei",
                    illustrator = "Não sei",
                    originallypublished = new DateTime(),
                    pageCount = 200,
                }

            };
            var livro2 = new Livro()
            {
                Id = 2,
                name = "Naruto",
                price = 2,
                Specifications = new Specifications()
                {
                    author = "Kishimoto",
                    genres = "Não sei",
                    illustrator = "Não sei",
                    originallypublished = new DateTime(),
                    pageCount = 200,
                }

            };
            var livro3 = new Livro()
            {
                Id = 3,
                name = "Boruto",
                price = 5.5,
                Specifications = new Specifications()
                {
                    author = "Kishimoto",
                    genres = "Não sei",
                    illustrator = "Não sei",
                    originallypublished = new DateTime(),
                    pageCount = 200,
                }

            };
            _storage.Add(livro1);
            _storage.Add(livro2);
            _storage.Add(livro3);
        }

        public void Adicionar(Livro livro)
        {
            _storage.Add(livro);
        }
        public IEnumerable<Livro> filterByName(string name)
        {

            var livroBuscado = _storage.FindAll(c => c.name == name);
            return livroBuscado;

        }

        public IEnumerable<Livro> filterByAuthor(string author)
        {
            var autorBuscado = _storage.FindAll(c => c.Specifications.author == author);
            return autorBuscado;
        }

        public IEnumerable<Livro> ListarLivros()
        {
            return _storage;
        }

        public IEnumerable<Livro> sortByPrice()
        {
            var livroOrdenado = _storage.OrderByDescending(c => c.price);
            return livroOrdenado.ToList();
        }
        public IEnumerable<Livro> sortByPriceAscendent()
        {
            var livroOrdenado = _storage.OrderBy(c => c.price);
            return livroOrdenado.ToList();
        }

        public IEnumerable<Livro> livroFrete(int Id)
        {
            var freteLivro = _storage.FindAll(c => c.Id == Id);
            if (freteLivro == null)
            {
                throw new ArgumentNullException("Livro não encontrado");
            }

            double frete = freteLivro.Find(c => c.Id == Id).price;

            Console.WriteLine("O custo do frete é de:" + frete*0.20);
            return freteLivro.ToList();
        }
    }
}
