using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class Key
{
    public Guid Identifier { get; set; }

    public string KeyValue { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
