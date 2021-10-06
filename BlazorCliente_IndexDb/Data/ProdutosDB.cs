using BlazorCliente_IndexDb.Entities;
using IndexedDB.Blazor;
using Microsoft.JSInterop;

namespace BlazorCliente_IndexDb.Data
{
    public class ProdutosDB : IndexedDb
    {
        public ProdutosDB(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<Produto> Produto { get; set; }
    }

}
