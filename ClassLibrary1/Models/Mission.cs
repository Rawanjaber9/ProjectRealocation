using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Mission
{
    public string CategoryName { get; set; } = null!;

    public int MissionNumber { get; set; }

    public string? MissionName { get; set; }

    public string? Description { get; set; }

    public int? MissionRange { get; set; }

    public DateTime? MissionStartDate { get; set; }

    public DateTime? MissionEndDate { get; set; }

    public string? ExecutionStatus { get; set; }

    public string? Urgency { get; set; }

    public string? Location { get; set; }

    public string? PersnoalRemark { get; set; }

    public string? Opinion { get; set; }

    public int? AlertNumber { get; set; }

    public string? UserName { get; set; }

    public virtual Alert? AlertNumberNavigation { get; set; }

    public virtual Category CategoryNameNavigation { get; set; } = null!;

    public virtual User? UserNameNavigation { get; set; }
}
