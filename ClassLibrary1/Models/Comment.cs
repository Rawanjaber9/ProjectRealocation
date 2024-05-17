using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models;

public partial class Comment
{
    public int CommentNumber { get; set; }

    public string? CommentContent { get; set; }

    public DateTime? PostDate { get; set; }

    public virtual ICollection<GetPostComment> GetPostComments { get; set; } = new List<GetPostComment>();
}
