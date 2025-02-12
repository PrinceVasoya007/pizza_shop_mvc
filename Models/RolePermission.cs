using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class RolePermission
{
    public int Id { get; set; }

    public int PermissionId { get; set; }

    public int RoleId { get; set; }

    public bool? Canview { get; set; }

    public bool? Canedit { get; set; }

    public bool? Candelete { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User Permission { get; set; } = null!;

    public virtual User Role { get; set; } = null!;
}
