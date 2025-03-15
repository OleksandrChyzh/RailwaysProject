using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TicketService : GenericService<Ticket, TicketModel>, ITicketService
    {
        protected override IRepository<Ticket> _repository { get; set; }

        public TicketService(IUnitOfWork uof, IMapper mapper)
            : base(uof, mapper)
        {
            _repository = uof.TicketRepository;
        }

        public async Task<IEnumerable<TicketModel>> GetAvailableTicketsAsync()
        {
            var tickets = await _repository.GetAllAsync();
            var now = DateTime.Now;
            var availableTickets = tickets.Where(t =>
                t.Date.Date > now.Date ||
                (t.Date.Date == now.Date && t.StationTrainId2Navigation.ArrivalTime.ToTimeSpan() > now.TimeOfDay));
            return _mapper.Map<IEnumerable<TicketModel>>(availableTickets);
        }

        public async Task<IEnumerable<TicketModel>> GetTicketHistoryAsync()
        {
            var tickets = await _repository.GetAllAsync();
            var now = DateTime.Now;
            var pastTickets = tickets.Where(t =>
                t.Date.Date < now.Date ||
                (t.Date.Date == now.Date && t.StationTrainId2Navigation.ArrivalTime.ToTimeSpan() <= now.TimeOfDay));
            return _mapper.Map<IEnumerable<TicketModel>>(pastTickets);
        }
    }
}
