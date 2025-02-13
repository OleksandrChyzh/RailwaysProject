﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TrainRepository : Repository<Train>, ITrainRepository
    {
        public TrainRepository(RailwayContext context) : base(context) { }
    }
}
