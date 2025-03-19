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

    public int StationTrainId1 { get; set; }

    public int StationTrainId2 { get; set; }

    public DateTime Date { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    public virtual StationsTrain StationTrainId2Navigation { get; set; } = null!;

    public virtual StationsTrain StationTrainId1Navigation { get; set; } = null!;

    public virtual User UserEmailNavigation { get; set; } = null!;
}
