using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IStationRepository StationRepository { get; }
        IStationsTrainRepository StationsTrainRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITrainRepository TrainRepository { get; }
        IUserRepository UserRepository { get; }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        Task SaveAsync();

    }
}
