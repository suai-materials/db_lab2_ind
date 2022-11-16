using System;
using System.Collections.Generic;

namespace DbContext;

public partial class Manufacture2Component
{
    public string? Name { get; set; }

    public long? TypeId { get; set; }

    public string? Brand { get; set; }

    public long? ManufacturerId { get; set; }

    public long? ManCountry { get; set; }

    public string? ReleaseDate { get; set; }

    public string? Characteristics { get; set; }

    public string? Warranty { get; set; }

    public string? Description { get; set; }

    public long? Price { get; set; }
}
