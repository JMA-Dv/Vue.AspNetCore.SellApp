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
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<OrderDto>>> GetAll(int page, int take) => await _service.GetAll(page, take);

        [HttpPost]
        public async Task<ActionResult> Create(OrderCreateDto model)
        {
            var result = await _service.Create(model);
            return CreatedAtAction("GetById", new { id = result.OrderId }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id) => await _service.GetById(id);
    }
}
