using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;


namespace BusinessLogic.Interfaces
{
    public interface ITrainService : ICrud<TrainModel>
    {
        Task<IEnumerable<TrainModel>> GetTrainsByTwoStations(StationModel station1, StationModel ststion2);
    }
}
