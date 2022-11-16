using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Manufacturer
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Component> Components { get; } = new List<Component>();
}
