using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StationsTrainRepository : Repository<StationsTrain>, IStationsTrainRepository
    {
        public StationsTrainRepository(RailwayContext context) : base(context) { }
    }
}