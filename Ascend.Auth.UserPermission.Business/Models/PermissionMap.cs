using Ascend.Auth.UserPermission.Data.Entities;

namespace Ascend.Auth.UserPermission.Business.Models {
    public static class PermissionMap {

        public static PermissionDTO ToDto(this Permission source)
        {
            if (source == null) return new PermissionDTO();

            return new PermissionDTO
            {
                Key = source.Key.KeyValue,
                Value = source.Value
            };

        }
    }
}
