using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BusinessLogic.Services
{
    public class StationService : GenericService<Station, StationModel>, IStationSevice
    {
        protected override IRepository<Station> _repository { get; }

        public StationService(IUnitOfWork uof, IMapper mapper)
            : base(uof, mapper)
        {
            _repository = uof.StationRepository;
        }
    }
}
