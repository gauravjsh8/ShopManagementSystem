using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Common;
using ShopManagementSystem.Services;

namespace ShopManagementSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly IItemServices _services;
        public ItemController(IItemServices services)
        {
            _services = services;
        }
        // Add Item
        [HttpPost]
        public IResult<ItemDTO> Post(ItemDTO model)
        {
            return _services.Add(model);
        }
        // Get All Items
        [HttpGet]
        public IResult<IEnumerable<ItemDTO>> Get()
        {
            return _services.GetAll();
        }
        // Get Single Item
        [HttpGet]
        [Route("{id:int}")]
        public IResult<ItemDTO> Get(int id){
            return _services.GetItem(id);
            }
        // Get Delete Items
        [HttpDelete]
        [Route("{id:int}")]
        public IResult<int> Remove(int id)
        {
            return _services.Remove(id);
        }
    }
}
