using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<ProductDto>>> GetAll(int page = 1, int take = 2)
        {
            var identity = this.User.Identity;
            return await _service.GetAll(page, take);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByid(int id) => await _service.GetById(id);
        

        [HttpPost]
        public async Task<ActionResult> Create(ProductCreateDto model)
        {
            var result = await _service.Create(model);
            return CreatedAtAction("GetById", new { id = result.ProductId }, result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id , ProductCreateDto model)
        {
            await _service.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
        
    }


}
