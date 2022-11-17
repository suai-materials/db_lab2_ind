using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Order
{
    public string OrderDate { get; set; } = null!;

    public string DueDate { get; set; } = null!;

    public long CustomerId { get; set; }

    public long? ComponentId1 { get; set; }

    public long? ComponentId2 { get; set; }

    public long? ComponentId3 { get; set; }

    public double PayProportion { get; set; }

    public byte[] IsPayed { get; set; } = null!;

    public byte[] IsExecute { get; set; } = null!;

    public string GeneralWarranty { get; set; } = null!;

    public long? ServiceId1 { get; set; }

    public long? ServiceId2 { get; set; }

    public long? ServiceId3 { get; set; }

    public long EmployeeId { get; set; }

    public virtual Component? ComponentId1Navigation { get; set; }

    public virtual Component? ComponentId2Navigation { get; set; }

    public virtual Component? ComponentId3Navigation { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Service? ServiceId1Navigation { get; set; }

    public virtual Service? ServiceId2Navigation { get; set; }

    public virtual Service? ServiceId3Navigation { get; set; }
}
