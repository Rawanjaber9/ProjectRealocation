using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Alert
{
    public int AlertNumber { get; set; }

    public string? AlertName { get; set; }

    public DateTime? AlertDate { get; set; }

    public string? AlertType { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<GetPostComment> GetPostComments { get; set; } = new List<GetPostComment>();

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();

    public virtual User? UserNameNavigation { get; set; }
}
