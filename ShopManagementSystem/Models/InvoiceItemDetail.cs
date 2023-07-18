using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementSystem.Models
{
    public class InvoiceItemDetail
    {
        [Key]
        public int Id { get; set; }
        public string quantity { get; set; }
        public int  ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Items { get; set; }

        public int MasterId { get; set; }
        [ForeignKey("MasterId")]
        public InvoiceMaster? InvoiceMasters { get; set; }

    }
}
