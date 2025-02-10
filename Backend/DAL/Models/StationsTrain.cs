using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class StationsTrain
{
    public long Id { get; set; }

    public long TrainNumber { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public long? StationId { get; set; }

    public virtual Station? Station { get; set; }

    public virtual ICollection<Ticket> TicketSationTrainId2Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketStationTrainId1Navigations { get; set; } = new List<Ticket>();

    public virtual Train TrainNumberNavigation { get; set; } = null!;
}
