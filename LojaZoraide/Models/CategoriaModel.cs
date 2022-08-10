using System.ComponentModel.DataAnnotations;

namespace LojaZoraide.Models
{
    public class CategoriaModel
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public List<ProdutoModel> Produtos { get; set; }
    }
}
