using System.ComponentModel.DataAnnotations;

namespace BlazorCliente_IndexDb.Entities
{

    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string preco { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} - Descrição:{Descricao} - Preço: {preco}";
        }
    }
}
