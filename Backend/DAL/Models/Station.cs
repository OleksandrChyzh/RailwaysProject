using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Station
{
    public long Id { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<StationsTrain> StationsTrains { get; set; } = new List<StationsTrain>();
}
