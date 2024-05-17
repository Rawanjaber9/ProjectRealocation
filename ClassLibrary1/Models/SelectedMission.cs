using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class SelectedMission
{
    public string UserName { get; set; } = null!;

    public int MissionNumber { get; set; }

    public virtual User UserNameNavigation { get; set; } = null!;
}
