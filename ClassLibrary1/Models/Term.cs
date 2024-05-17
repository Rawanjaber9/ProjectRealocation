using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Term
{
    public int VersionNumber { get; set; }

    public string? Details { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? ChangesHistory { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
