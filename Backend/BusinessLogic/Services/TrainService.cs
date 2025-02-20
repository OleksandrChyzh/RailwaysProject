using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TrainService : GenericService<Train, TrainModel>, ITrainService
    {
        protected override IRepository<Train> _repository { get; }

        public TrainService(IUnitOfWork uof, IMapper mapper)
            : base(uof, mapper)
        {
            _repository = uof.TrainRepository;
        }

        public async Task<IEnumerable<TrainModel>> GetTrainsByTwoStations(StationModel station1, StationModel station2)
        {
            var trains = await _repository.GetAllAsync();

            var filteredTrains = trains
                .Where(train => train.StationsTrains.Any(st => st.StationId == station1.Id) &&
                                train.StationsTrains.Any(st => st.StationId == station2.Id))
                .ToList();

            if (!filteredTrains.Any() || station1.Id >= station2.Id)
            {
                throw new InvalidOperationException("Немає поїздів за заданим маршрутом");
            }
            return _mapper.Map<IEnumerable<TrainModel>>(filteredTrains);
        }

    }
}
