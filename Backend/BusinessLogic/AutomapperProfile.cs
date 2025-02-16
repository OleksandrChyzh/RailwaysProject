using AutoMapper;
using DAL.Entities;
using BusinessLogic.Models;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Net.Sockets;


namespace BusinessLogic
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Station Mapping
            CreateMap<Station, StationModel>().ReverseMap();

            // Train Mapping
            CreateMap<Train, TrainModel>().ReverseMap();

            // User Mapping
            CreateMap<User, UserModel>().ReverseMap();

            // Ticket Mapping
            CreateMap<Ticket, TicketModel>()
                .ForMember(tm => tm.TrainName, t => t.MapFrom(x => x.StationTrainId1Navigation.TrainNumberNavigation.TrainName))
                .ForMember(tm => tm.StartStationName, t => t.MapFrom(x => x.StationTrainId1Navigation.Station.City))
                .ForMember(tm => tm.EndStationName, t => t.MapFrom(x => x.StationTrainId2Navigation.Station.City))
                .ReverseMap();
        }
    }
}
