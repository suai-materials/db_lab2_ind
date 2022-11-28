using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Employee : object
{
    public long Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public long Age { get; set; }

    public long Sex { get; set; }

    public string? Address { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string PassportDetails { get; set; } = null!;

    public long PositionId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Position Position { get; set; } = null!;

    public virtual Sex SexNavigation { get; set; } = null!;
}