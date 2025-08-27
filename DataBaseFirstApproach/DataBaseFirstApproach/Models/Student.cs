using System;
using System.Collections.Generic;

namespace DataBaseFirstApproach.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public string StudentStandard { get; set; } = null!;
}
