using ShopManagementSystem.Common;
using ShopManagementSystem.Data;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Services
{
    public class ItemService : IItemServices
    {
        public readonly AppDbContext _context;
        public ItemService(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        ///   Add Item to Database
        /// </summary>

      public   IResult<ItemDTO> Add(ItemDTO model)
        {
            if (model == null)
            {
                return new IResult<ItemDTO>()
                {
                    ResultStatus = status.failure,
                };
            }
            var item = new Item()
            {
                Id = model.Id,
                Discount = model.Discount,
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock

            };

            _context.Items.Add(item);
            _context.SaveChanges();
            return new IResult<ItemDTO>()
            {   Data=model,
                ResultStatus = status.success,
                message = "Item Added Successfully"

            };
        }


        /// <summary>
        ///   Get All List of Data
        /// </summary>

      public  IResult<IEnumerable<ItemDTO>> GetAll()
        {
            var data = _context.Items.ToList();
            if(data == null)
            {
                return new IResult<IEnumerable<ItemDTO>>()
                {
                    message = "No result found",
                    ResultStatus =status.failure

                };
            }
           var data2 = (from c in data
                    select new ItemDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Discount = c.Discount,
                        Price = c.Price,
                        Stock = c.Stock
                    }).ToList();

            return new IResult<IEnumerable<ItemDTO>> { 
            Data =data2,
            ResultStatus = status.success
            };
        }

        


        /// <summary>
        ///  Get Single Item
        /// </summary>

      public  IResult<ItemDTO> GetItem(int id)
        {
            var data = _context.Items.Find(id);
            if (data == null)
            {
                return new IResult<ItemDTO>()
                {
                    message = "Your id is invalid",
                    ResultStatus = status.failure
                };
            }
            var data2 = ( new ItemDTO()
            {
                Id = data.Id,
                Name = data.Name,
                Discount = data.Discount,
                Price = data.Price,
                Stock = data.Stock
            });
           
            return new IResult<ItemDTO>()
            {
                Data = data2,
                message = "Success",
                ResultStatus = status.success
              
            };

        }
        /// <summary>
        ///   Delete Action
        /// </summary>
       

      public   IResult<int> Remove(int id)
        {
          var  data = _context.Items.Find(id);
            if(data != null)
            {
                _context.Items.Remove(data);
                _context.SaveChanges();
                return new IResult<int>()
                {
                    message = "Data Deleted Successfully",
                    ResultStatus = status.success
                };
            };
            return new IResult<int>()
            {
                message = "No data Matched",
                ResultStatus = status.failure
            };

        }

       
    }
}
