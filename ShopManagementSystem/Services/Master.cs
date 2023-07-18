using ShopManagementSystem.Common;
using ShopManagementSystem.Data;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Services
{
    public class Master : IMaster
    {
        public readonly AppDbContext _context;
        public Master(AppDbContext context)
        {
            _context = context;
        }
        public IResult<InvoiceDTO> Add(InvoiceDTO model)
        {
            if (model == null)
            {
                return new IResult<InvoiceDTO>()
                {
                    message = "Model is Empty or invalid",
                    ResultStatus = status.failure
                };
            }
            var master = model.Master;
            var masterdata = new InvoiceMaster()
            {
                CustomerId = master.CustomerId,

            };
            var ItemDetail = model.ItemDetail;
            var ItemDetails = (from c in ItemDetail
                               select new InvoiceItemDetail()
                               {
                                   ItemId = c.ItemId,
                                   quantity = c.quantity
                               }).ToList();

            _context.InvoiceMasters.Add(masterdata);
            _context.InvoiceItemDetails.AddRange(ItemDetails);
            _context.SaveChanges();
            return new IResult<InvoiceDTO>()
            {
                message = "Added Successfully",
                ResultStatus = status.success
            };
            //foreach (var item in ItemDetail)
            //{
            //    var ItemDetailData = new InvoiceItemDetail()
            //    {
            //        quantity=item.quantity,
            //        ItemId = item.ItemId
            //  };
            //}

        }

        public IResult<IEnumerable<InvoiceDTO>> GetAll()
        {
            var masterData = _context.InvoiceMasters.AsQueryable();
            var ItemDetail = _context.InvoiceItemDetails.AsQueryable();
            var masterDataDto = (from m in masterData
                                select new InvoiceDTO()
                                {
                                    Master = new InvoiceMasterDTO()
                                    {
                                        CustomerId = m.CustomerId,
                                        customerName = _context.Customers.Find(m.CustomerId).Name,
                                        phoneNumber = _context.Customers.Find(m.CustomerId).ContactNo,

                                    },
                                    ItemDetail = (from c in ItemDetail.Where(x => x.MasterId == m.MasterId)
                                                  select new InvoiceItemDetailDTO()
                                                  {
                                                      discount = _context.Items.Find(c.ItemId).Discount,
                                                      name = _context.Items.Find(c.ItemId).Name,
                                                      price = _context.Items.Find(c.ItemId).Price,
                                                      quantity = c.quantity,
                                                      ItemId = c.ItemId

                                                  }).AsQueryable()
                                }).AsEnumerable();


            return new IResult<IEnumerable<InvoiceDTO>>()
            {
                Data= masterDataDto,
               ResultStatus =status.success
            };
        }

        public IResult<InvoiceDTO> GetSingleInvoice(int id)
        {
            var masterData = _context.InvoiceMasters.Find(id);
            var detailItem = _context.InvoiceItemDetails.Where(e=>e.MasterId ==id);
            if(masterData ==null || detailItem == null)
            {
                return new IResult<InvoiceDTO>()
                {
                    message = "No Data Found",
                    ResultStatus = status.failure
                };
       
            }
            InvoiceDTO singleItemDTO = (new InvoiceDTO()
            {
                Master = new InvoiceMasterDTO()
                {
                    CustomerId = masterData.CustomerId,
                    customerName = _context.Customers.Find(masterData.CustomerId).Name,
                    phoneNumber = _context.Customers.Find(masterData.CustomerId).ContactNo,
                },
                ItemDetail = (from c in detailItem.Where(x => x.MasterId == masterData.CustomerId)
                              select new InvoiceItemDetailDTO()
                              {
                                  discount = _context.Items.Find(c.ItemId).Discount,
                                  name= _context.Items.Find(c.ItemId).Name,
                                  quantity = c.quantity,
                                  price =_context.Items.Find(c.ItemId).Price,
                                  ItemId =c.ItemId
                              })
            }); 
            return new IResult<InvoiceDTO>()
            {
                message = "Data Found",
                Data = singleItemDTO
            };
        }
    }
        
    }

