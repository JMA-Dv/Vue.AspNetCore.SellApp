using AutoMapper;
using Model;
using Model.DTOs;
using Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Api.Config
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();

            CreateMap<Product, ProductDto>();
            CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailsDto>();
            CreateMap<DataCollection<Order>, DataCollection<OrderDto>>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap < OrderDetailCreateDto, OrderDetail>();
            


        }
    }
}
