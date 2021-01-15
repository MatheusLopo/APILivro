using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ILivroRepository
    {
        void Adicionar(Livro livro);
        IEnumerable<Livro> ListarLivros();
        IEnumerable<Livro>  sortByPrice();
        IEnumerable<Livro> sortByPriceAscendent();
        IEnumerable<Livro> filterByName(string name);
        IEnumerable<Livro> filterByAuthor(String author);

        IEnumerable<Livro> livroFrete(int Id);
        
    }
}
