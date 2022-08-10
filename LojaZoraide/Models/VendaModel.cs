using System.ComponentModel.DataAnnotations;

namespace LojaZoraide.Models
{
    public class VendaModel
    {
        [Key()]
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double TotalVenda { get; set; }

        public int ClienteModelId { get; set; }
        public ClienteModel ClienteModel { get; set; }
        
       
        public List<ItemVendaModel> ItemsVenda { get; set; }


    }
}
