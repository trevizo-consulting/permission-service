using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class Group
{
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;

    public bool Deleted { get; set; }
}
