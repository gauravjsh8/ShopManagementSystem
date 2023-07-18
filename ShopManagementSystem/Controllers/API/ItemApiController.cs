using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Common;
using ShopManagementSystem.Services;

namespace ShopManagementSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        public readonly IItemServices _services;
        public ItemApiController(IItemServices services)
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


        //search
        [HttpGet("Search")]
        public   IResult<IEnumerable<ItemDTO>> Search(string search)
        {
            return _services.Search(search);
        }

        [HttpDelete("{id}")]
      public  IResult<int> Delete(int id)
        {
            return _services.Remove(id);
        }

        // Get Single Item
        [HttpGet]
        [Route("{id:int}")]
        public IResult<ItemDTO> Get(int id) {
            return _services.GetItem(id);
        }

        [HttpPut]
        public IResult<ItemDTO> Update( ItemDTO model){
            return _services.Update( model);
        }
    }
}
