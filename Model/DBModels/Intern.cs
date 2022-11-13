using System;
using System.Collections.Generic;

namespace Model.DBModels;

public partial class Intern
{
    public int InternId { get; set; }

    public string? InternName { get; set; }

    public string? Mentor { get; set; }

    public string? CurrentTrainings { get; set; }
}
