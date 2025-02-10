using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Train
{
    public long Id { get; set; }

    public string TrainName { get; set; } = null!;

    public long PricePerInterval { get; set; }

    public long? NumberOfWagons { get; set; }

    public long? NumberOfSeats { get; set; }

    public virtual ICollection<StationsTrain> StationsTrains { get; set; } = new List<StationsTrain>();
}
