using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
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
    }
}
