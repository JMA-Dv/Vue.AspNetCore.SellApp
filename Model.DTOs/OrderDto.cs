using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetailsDto> Items { get; set; }

    }

    public class OrderCreateDto
    {
        public int ClientId { get; set; }
        
        public List<OrderDetailCreateDto> Items { get; set; }
    }


}
