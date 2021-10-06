using BlazorCliente_IndexDb.Data;
using BlazorCliente_IndexDb.Entities;
using IndexedDB.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BlazorCliente_IndexDb.Repository
{
    #region Interface
    public interface IProdutoRepository
    {
        Task Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task<Produto> Get(int id);
        Task<IEnumerable<Produto>> Get();
    }
    #endregion

    public class ProdutoRepository : IProdutoRepository
    {
        private ProdutosDB _contexto;
        public ProdutoRepository(IIndexedDbFactory dbFactory)
        {
            _contexto = dbFactory.Create<ProdutosDB>().Result;
        }

        public async Task Create(Produto produto)
        {
            _contexto.Produto.Add(produto);
            await _contexto.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var produtoRemove = new Produto { Id = id };
            _contexto.Produto.Remove(produtoRemove);
            await _contexto.SaveChanges();
        }

        public async Task<Produto> Get(int id)
        {
            var produto = _contexto.Produto.FirstOrDefault(x => x.Id == id);
            return await Task .FromResult(produto);
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            var produtos = _contexto.Produto.ToList();
            return await Task.FromResult(produtos);
        }

        public async Task Update(Produto produto)
        {
           var upProduto = _contexto.Produto.Single(x => x.Id == produto.Id);
            upProduto.Descricao = produto.Descricao;
            upProduto.preco = produto.preco;
            await _contexto.SaveChanges();
        }

    }
}

