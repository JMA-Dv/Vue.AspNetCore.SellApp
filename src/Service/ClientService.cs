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

    public interface IClientService
    {
        Task<ClientDto> Create(ClientDto model);
        Task<ClientDto> GetById(int id);
        Task Update(int id, ClientUpdateDto model);
        Task Delete(int id);

        Task<DataCollection<ClientDto>> GetAll(int page, int take );
    }

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDto> Create(ClientDto model)
        {
            var entry = new Client
            {
                Name = model.Name
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDto>(entry);
        }

        public async Task Delete(int id)
        {
            _context.Remove(
           new Client
           {
               ClientId = id
           });

            await _context.SaveChangesAsync();
        }

        public async Task<DataCollection<ClientDto>> GetAll(int page, int take)
        {

            return _mapper.Map<DataCollection<ClientDto>>(
                await _context.Clients.OrderByDescending(x => x.ClientId)
                .AsQueryable()
                .PagedAsync(page, take));

        }

        public async Task<ClientDto> GetById(int id) => _mapper.Map<ClientDto>(await _context.Clients.SingleAsync(x => x.ClientId == id));

        public async Task Update(int id, ClientUpdateDto model)
        {
            var entry = await _context.Clients.SingleAsync(x => x.ClientId == id);
            entry.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
