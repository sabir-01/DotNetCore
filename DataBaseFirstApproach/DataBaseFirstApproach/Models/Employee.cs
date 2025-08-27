using System;
using System.Collections.Generic;

namespace DataBaseFirstApproach.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? JoiningDate { get; set; }
}
