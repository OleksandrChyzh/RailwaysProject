﻿using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Train:BaseEntity
{
    public string TrainName { get; set; } = null!;

    public long PricePerInterval { get; set; }

    public long? NumberOfWagons { get; set; }

    public long? NumberOfSeats { get; set; }

    public virtual ICollection<StationsTrain> StationsTrains { get; set; } = new List<StationsTrain>();
}
