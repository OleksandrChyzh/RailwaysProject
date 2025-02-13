using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Station: BaseEntity
{
    public string City { get; set; } = null!;

    public virtual ICollection<StationsTrain> StationsTrains { get; set; } = new List<StationsTrain>();
}
