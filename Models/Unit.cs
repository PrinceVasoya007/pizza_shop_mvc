using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string ShotName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int CreatedBy { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Modifier> Modifiers { get; } = new List<Modifier>();
}
