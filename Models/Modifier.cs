using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Modifier
{
    public int Id { get; set; }

    public int ModifierGroupId { get; set; }

    public string Name { get; set; } = null!;

    public int? UnitId { get; set; }

    public decimal Rate { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ModifierGroup ModifierGroup { get; set; } = null!;

    public virtual ICollection<OrderedItemModifierMapping> OrderedItemModifierMappings { get; } = new List<OrderedItemModifierMapping>();

    public virtual Unit? Unit { get; set; }
}
