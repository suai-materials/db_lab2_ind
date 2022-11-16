using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Position
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Salary { get; set; }

    public string? Responsibilities { get; set; }

    public string? Requirements { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
