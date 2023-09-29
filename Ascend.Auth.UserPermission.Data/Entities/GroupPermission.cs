using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class GroupPermission
{
    public Guid Identifier { get; set; }

    public Guid GroupIdentifier { get; set; }

    public Guid PermissionIdentifier { get; set; }

    public int? OrganizationId { get; set; }

    public int? SubUnitId { get; set; }
}
