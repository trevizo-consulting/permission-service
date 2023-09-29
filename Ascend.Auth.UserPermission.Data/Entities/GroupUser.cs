using System;
using System.Collections.Generic;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class GroupUser
{
    public Guid Identifier { get; set; }

    public int UserId { get; set; }

    public Guid GroupIdentifier { get; set; }
}
