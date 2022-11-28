using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Country
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Component> Components { get; } = new List<Component>();
}