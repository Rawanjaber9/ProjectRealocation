using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
