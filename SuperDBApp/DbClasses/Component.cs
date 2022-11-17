using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Component
{
    public long Id { get; set; }

    public long TypeId { get; set; }

    public string Brand { get; set; } = null!;

    public long ManufacturerId { get; set; }

    public long ManCountry { get; set; }

    public string ReleaseDate { get; set; } = null!;

    public string Characteristics { get; set; } = null!;

    public string Warranty { get; set; } = null!;

    public string? Description { get; set; }

    public long Price { get; set; }

    public virtual Country ManCountryNavigation { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Order> OrderComponentId1Navigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderComponentId2Navigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderComponentId3Navigations { get; } = new List<Order>();

    public virtual Type Type { get; set; } = null!;
}
