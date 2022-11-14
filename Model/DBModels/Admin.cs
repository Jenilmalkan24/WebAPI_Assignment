using System;
using System.Collections.Generic;

namespace Model.DBModels;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? Manager { get; set; }

    public string? Email { get; set; }
}
