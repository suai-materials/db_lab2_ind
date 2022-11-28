using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Type
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Component> Components { get; } = new List<Component>();
}