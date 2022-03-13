using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class OrderDetailsDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        
    }
}
