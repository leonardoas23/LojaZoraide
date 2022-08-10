using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaZoraide.Models
{
    public class ItemVendaModel
    {
        [Key, Column(Order = 0)]
        public int? ProdutoModelId { get; set; }
        public ProdutoModel ProdutoModel { get; set; }

        [Key, Column(Order = 1)]
        public int? VendaModelId { get; set; }
        public VendaModel VendaModel { get; set; }

        public int MetodoPagamento { get; set; }
        public double ValorProduto { get; set; }
        public double Desconto  { get; set; }     
        public int QuantidadeProduto { get; set; }
        
        







    }
}
