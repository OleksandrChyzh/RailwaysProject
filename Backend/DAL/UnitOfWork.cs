using DAL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork(RailwayContext context) : IUnitOfWork
    {
        public IStationRepository StationRepository { get; set; } = new StationRepository(context);
        public IStationsTrainRepository StationsTrainRepository { get; set; } = new StationsTrainRepository(context);
        public ITicketRepository TicketRepository { get; set; } = new TicketRepository(context);
        public ITrainRepository TrainRepository { get; set; } = new TrainRepository(context);
        public IUserRepository UserRepository {  get; set; } = new UserRepository(context);

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return typeof(TEntity).Name switch
            {
                nameof(Station) => (IRepository<TEntity>)StationRepository,
                nameof(StationsTrain) => (IRepository<TEntity>)StationsTrainRepository,
                nameof(Ticket) => (IRepository<TEntity>)TicketRepository,
                nameof(Train) => (IRepository<TEntity>)TrainRepository,
                nameof(User) => (IRepository<TEntity>)UserRepository,
                _ => throw new InvalidOperationException($"Repository for type {typeof(TEntity)} not found"),
            };
        }
    }
}
