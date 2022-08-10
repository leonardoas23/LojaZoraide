using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaZoraide.Models
{
    public class ProdutoModel
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string  Estado { get; set; }       
        [NotMapped]
        public IFormFile Foto { get; set; }
        public byte[] FotoDB { get; set; }
        public int CategoriaModelId  { get; set; }
        public CategoriaModel CategoriaModel { get; set; }
     
        public string ToBase64()
        {

            var retorno = FotoDB == null ? string.Empty : Convert.ToBase64String(FotoDB);

            return retorno;
        }


        
    }
}
