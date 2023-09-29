using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class Permission
{
    public Guid Identifier { get; set; }

    public Guid KeyId { get; set; }

    public string Value { get; set; } = null!;

    public bool Deleted { get; set; }

    public virtual Key Key { get; set; } = null!;

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
