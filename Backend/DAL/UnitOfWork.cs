using DAL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RailwayContext _context;

        private readonly IStationRepository _stationRepository;
        public IStationRepository StationRepository => _stationRepository;
        private readonly IStationsTrainRepository _stationsTrainRepository;
        public IStationsTrainRepository StationsTrainRepository => _stationsTrainRepository;
        private readonly ITicketRepository _ticketRepository;
        public ITicketRepository TicketRepository => _ticketRepository;
        private readonly ITrainRepository _trainRepository;
        public ITrainRepository TrainRepository => _trainRepository;
        private readonly IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository;

        public UnitOfWork(RailwayContext context)
        {
            _context = context;
            _stationRepository = new StationRepository(_context);
            _stationsTrainRepository = new StationsTrainRepository(_context);
            _ticketRepository = new TicketRepository(_context);
            _trainRepository = new TrainRepository(_context);
            _userRepository = new UserRepository(_context);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return typeof(TEntity).Name switch
            {
                nameof(Station) => (IRepository<TEntity>)_stationRepository,
                nameof(StationsTrain) => (IRepository<TEntity>)_stationsTrainRepository,
                nameof(Ticket) => (IRepository<TEntity>)_ticketRepository,
                nameof(Train) => (IRepository<TEntity>)_trainRepository,
                nameof(User) => (IRepository<TEntity>)_userRepository,
                _ => throw new InvalidOperationException($"Repository for type {typeof(TEntity)} not found"),
            };
        }
    }
}
