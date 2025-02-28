using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IStationRepository StationRepository { get; }
        IStationsTrainRepository StationsTrainRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITrainRepository TrainRepository { get; }
        IUserRepository UserRepository { get; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        Task SaveAsync();

    }
}
