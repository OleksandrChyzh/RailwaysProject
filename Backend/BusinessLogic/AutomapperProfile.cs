using AutoMapper;
using DAL.Entities;
using BusinessLogic.Models;

namespace BusinessLogic
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Station, StationModel>().ReverseMap();

            CreateMap<Train, TrainModel>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<Ticket, TicketModel>()
                .ForMember(tm => tm.TrainName, t => t.MapFrom(x => x.StationTrainId1Navigation.TrainNumberNavigation.TrainName))
                .ForMember(tm => tm.StartStationName, t => t.MapFrom(x => x.StationTrainId1Navigation.Station.City))
                .ForMember(tm => tm.EndStationName, t => t.MapFrom(x => x.StationTrainId2Navigation.Station.City))
                .ReverseMap();
        }
    }
}
