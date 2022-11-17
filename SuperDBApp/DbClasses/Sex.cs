using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Sex
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
