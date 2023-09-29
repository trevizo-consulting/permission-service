using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.UserPermission;

public partial class Permission
{
    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public Guid Id { get; set; }
}
