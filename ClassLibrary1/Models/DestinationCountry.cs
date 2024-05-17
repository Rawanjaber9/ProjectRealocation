using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class DestinationCountry
{
    public string CountryName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
