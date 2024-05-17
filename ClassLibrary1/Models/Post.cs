using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Post
{
    public int PostNumber { get; set; }

    public string? Content { get; set; }

    public DateTime? PostDate { get; set; }

    public virtual ICollection<GetPostComment> GetPostComments { get; set; } = new List<GetPostComment>();
}
