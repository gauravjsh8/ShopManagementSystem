using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShopManagementSystem.Common;
using ShopManagementSystem.Services;

namespace ShopManagementSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDetailAPIController : ControllerBase
    {
        private readonly IMaster _service;
        public MasterDetailAPIController(IMaster service)
        {
            _service = service;
        }
        [HttpPost]
      public  IResult<InvoiceDTO> Post(InvoiceDTO model)
        {
           return _service.Add(model);
        }
        [HttpGet]
        public IResult<IEnumerable<InvoiceDTO>> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public IResult<InvoiceDTO> GetSingleItem(int id)
        {
            return _service.GetSingleInvoice(id);
        }
    }
}
