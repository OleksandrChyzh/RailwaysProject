using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Ticket: BaseEntity
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public long WagonNumber { get; set; }

    public long SeatNumber { get; set; }

    public long StationTrainId1 { get; set; }

    public long StationTrainId2 { get; set; }

    public virtual StationsTrain StationTrainId2Navigation { get; set; } = null!;

    public virtual StationsTrain StationTrainId1Navigation { get; set; } = null!;

    public virtual User UserEmailNavigation { get; set; } = null!;
}
