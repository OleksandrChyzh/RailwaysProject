using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(RailwayContext context) : base(context) { }
    }
}