using BlazorCliente_IndexDb.Data;
using BlazorCliente_IndexDb.Entities;
using IndexedDB.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BlazorCliente_IndexDb.Repository
{
    #region Interface
    public interface IProdutoRepository
    {
        Task Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task<Produto> Get(int id);
        Task<IEnumerable<Produto>> GetAll();
    }
    #endregion

    public class ProdutoRepository : IProdutoRepository , IDisposable
    {
        private IIndexedDbFactory DbFactory;
        public ProdutoRepository(IIndexedDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public async Task Create(Produto produto)
        {
            using (var _contexto = await this.DbFactory.Create<ProdutosDB>())
            {
                _contexto.Produto.Add(produto);
                await _contexto.SaveChanges();
            }
        }

        public async Task Delete(int id)
        {
            using (var _contexto = await this.DbFactory.Create<ProdutosDB>())
            {
                var produtoRemove = new Produto { Id = id };
                _contexto.Produto.Remove(produtoRemove);
                await _contexto.SaveChanges();
            }
        }    

        public async Task<Produto> Get(int id)
        {
            using (var _contexto = await this.DbFactory.Create<ProdutosDB>())
            {
                var produto = _contexto.Produto.FirstOrDefault(x => x.Id == id);
                return await Task.FromResult(produto);
            }
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            using (var _context = await this.DbFactory.Create<ProdutosDB>())
            {
                var produtos = _context.Produto.ToList();
                return await Task.FromResult(produtos);
            }
        }

        public async Task Update(Produto produto)
        {
            using (var _contexto = await this.DbFactory.Create<ProdutosDB>())
            {
                var upProduto = _contexto.Produto.Single(x => x.Id == produto.Id);
                upProduto.Descricao = produto.Descricao;
                upProduto.preco = produto.preco;
                await _contexto.SaveChanges();
            }
        }

        public void Dispose()
        {

        }
    }
}

