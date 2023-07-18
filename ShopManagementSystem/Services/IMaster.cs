using ShopManagementSystem.Common;

namespace ShopManagementSystem.Services
{
    public interface IMaster
    {
        IResult<InvoiceDTO> Add(InvoiceDTO model);
        IResult<IEnumerable<InvoiceDTO>> GetAll();
        IResult<InvoiceDTO> GetSingleInvoice(int id);
    }



    public class InvoiceMasterDTO
    {
        public int CustomerId { get; set; }
        public string? customerName  { get; set; }
        public string? phoneNumber { get; set; }
    }
    public class InvoiceItemDetailDTO
    {
        public string? quantity { get; set; }
        public decimal? price { get; set; }
        public string? name { get; set;}
        public int ?discount { get; set; }
        public int ItemId { get; set; }

    }
    public class InvoiceDTO
    {
        public InvoiceMasterDTO Master { get; set; }
        public IQueryable<InvoiceItemDetailDTO> ItemDetail { get; set; }

    }
}
