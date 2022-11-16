using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Service
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long Cost { get; set; }

    public virtual ICollection<Order> OrderServiceId1Navigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderServiceId2Navigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderServiceId3Navigations { get; } = new List<Order>();
}
