using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly List<Livro> _storage;

        public LivroRepository()
        {
            _storage = new List<Livro>();
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
            return livroOrdenado;
        }
        public IEnumerable<Livro> sortByPriceAscendent()
        {
            var livroOrdenado = _storage.OrderBy(c => c.price);
            return livroOrdenado;
        }

        public IEnumerable<Livro> livroFrete(int Id)
        {
            var freteLivro = _storage.FindAll(c => c.Id == Id);
            if(freteLivro == null)
            {
                throw new ArgumentNullException("Livro não encontrado");
            }
            double frete = freteLivro.Find(c=> c.Id == Id).price ;
            frete = frete * 0.20;
            Console.WriteLine("O custo do frete é de:" + frete);
            return freteLivro;
        }
       
    }
}
