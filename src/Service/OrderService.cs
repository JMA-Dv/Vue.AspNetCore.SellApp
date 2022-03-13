using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService: IBaseService<OrderDto,OrderCreateDto>
    {
    }
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const decimal IvaRate = 0.18m;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);
            PrepareDetail(entry.Items);
            PrepareHeader(entry);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDto>(
                await GetById(entry.OrderId)) ;
        }

        public async Task Delete(int id)
        {
            _context.Remove(new Client { ClientId = id });
            await _context.SaveChangesAsync();
        }

        public async Task<DataCollection<OrderDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(await 
                _context.Orders.Include(x=> x.Client)
                .Include(x=> x.Items).ThenInclude(x=> x.Product)
                
                .OrderByDescending(x => x.OrderId).AsQueryable().PagedAsync(page, take));
        }

        public async Task<OrderDto> GetById(int id)
        {
            return _mapper.Map<OrderDto>(
            await _context.Orders
            .Include(x=> x.Client)
            .Include(x=> x.Items).ThenInclude(x=> x.Product)
            .SingleAsync(x => x.OrderId == id));

        }

        public async Task Update(int id, OrderCreateDto model)
        {
            var snippet = await _context.Orders.SingleAsync(x => x.OrderId == id);

        }

        private void PrepareDetail(IEnumerable<OrderDetail> items)
        {
            foreach(var item in items)
            {
                item.Subtotal = item.Quantity * item.UnitPrice;
                item.Iva = item.Subtotal * IvaRate;
                item.Total = item.Subtotal + item.Iva;
                //item.Total = item.UnitPrice * item.Quantity;
                //item.Iva = item.Total * IvaRate;
                //item.Subtotal = item.Total - item.Iva;
            }
        }
        private void PrepareHeader(Order order)
        {
            order.Subtotal = order.Items.Sum(x => x.Subtotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }
        
    }
}
