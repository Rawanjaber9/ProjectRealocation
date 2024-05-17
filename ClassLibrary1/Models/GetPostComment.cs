using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class GetPostComment
{
    public int PostNumber { get; set; }

    public int CommentNumber { get; set; }

    public string? UserName { get; set; }

    public int? AlertNumber { get; set; }

    public string? CountryName { get; set; }

    public virtual Alert? AlertNumberNavigation { get; set; }

    public virtual Comment CommentNumberNavigation { get; set; } = null!;

    public virtual Post PostNumberNavigation { get; set; } = null!;

    public virtual User? UserNameNavigation { get; set; }
}
