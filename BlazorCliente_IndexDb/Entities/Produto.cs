using System.ComponentModel.DataAnnotations;

namespace BlazorCliente_IndexDb.Entities
{

    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string preco { get; set; }
    }
}
