using System;
using System.Collections.Generic;

namespace DbContext;

public partial class CustomerOrder
{
    public long? Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? OrderDate { get; set; }

    public string? DueDate { get; set; }

    public long? CustomerId { get; set; }

    public long? ComponentId1 { get; set; }

    public long? ComponentId2 { get; set; }

    public long? ComponentId3 { get; set; }

    public double? PayProportion { get; set; }

    public byte[]? IsPayed { get; set; }

    public byte[]? IsExecute { get; set; }

    public string? GeneralWarranty { get; set; }

    public long? ServiceId1 { get; set; }

    public long? ServiceId2 { get; set; }

    public long? ServiceId3 { get; set; }

    public long? EmployeeId { get; set; }
}