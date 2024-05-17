using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? TransitionDate { get; set; }

    public bool? KidsYn { get; set; }

    public string? CountryName { get; set; }

    public int? VersionNumber { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual DestinationCountry? CountryNameNavigation { get; set; }

    public virtual ICollection<GetPostComment> GetPostComments { get; set; } = new List<GetPostComment>();

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();

    public virtual ICollection<SelectedMission> SelectedMissions { get; set; } = new List<SelectedMission>();

    public virtual Term? VersionNumberNavigation { get; set; }
}
