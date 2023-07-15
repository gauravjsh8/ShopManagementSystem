using ShopManagementSystem.Common;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Services
{
    public interface IItemServices
    {
        IResult<IEnumerable<ItemDTO>> GetAll();
         IResult<ItemDTO>  GetItem(int id);
         IResult<ItemDTO> Add(ItemDTO model);
         IResult<ItemDTO> Update(int id, ItemDTO model);
         IResult<int> Remove(int id);
    }
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
    }
}
