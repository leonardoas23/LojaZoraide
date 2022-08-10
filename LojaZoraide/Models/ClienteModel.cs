using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaZoraide.Models
{
    public class ClienteModel
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public double Divida { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }
        public byte[] FotoDB{ get; set; }

        public string ToBase64()
        {

           var retorno = FotoDB == null ? string.Empty : Convert.ToBase64String(FotoDB);

            return retorno;
        }
      public List<VendaModel> VendasModel { get; set; }
      

    }
}
