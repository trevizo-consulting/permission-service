using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class UserPermission
{
    public Guid Identifier { get; set; }

    public int UserId { get; set; }

    public Guid PermissionId { get; set; }

    public int? OrganizationId { get; set; }

    public int? SubUnitId { get; set; }

    public virtual Permission Permission { get; set; } = null!;
}
