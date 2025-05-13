using System;
using System.Collections.Generic;

namespace HR_Management.Models;

public partial class Et
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public int? Salary { get; set; }
}
