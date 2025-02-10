using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public long WagonNumber { get; set; }

    public long SeatNumber { get; set; }

    public long StationTrainId1 { get; set; }

    public long SationTrainId2 { get; set; }

    public virtual StationsTrain SationTrainId2Navigation { get; set; } = null!;

    public virtual StationsTrain StationTrainId1Navigation { get; set; } = null!;

    public virtual User UserEmailNavigation { get; set; } = null!;
}
