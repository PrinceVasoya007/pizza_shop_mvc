using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class MenuItem
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Type { get; set; }

    public decimal Rate { get; set; }

    public int? Quantity { get; set; }

    public int? UnitId { get; set; }

    public bool? IsAvailable { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public decimal? TaxPercentage { get; set; }

    public bool? IsFavourite { get; set; }

    public string? ShortCode { get; set; }

    public bool? IsDefaultTax { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual MenuCategory Category { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<MappingMenuItemWithModifier> MappingMenuItemWithModifiers { get; } = new List<MappingMenuItemWithModifier>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<OrderedItem> OrderedItems { get; } = new List<OrderedItem>();

    public virtual Unit? Unit { get; set; }
}
