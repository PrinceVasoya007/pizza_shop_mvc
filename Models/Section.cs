using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Table> Tables { get; } = new List<Table>();

    public virtual ICollection<WaitingToken> WaitingTokens { get; } = new List<WaitingToken>();
}
