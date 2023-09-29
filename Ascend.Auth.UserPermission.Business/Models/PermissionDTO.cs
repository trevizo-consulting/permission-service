using System;
using System.ComponentModel;


namespace Ascend.Auth.UserPermission.Business.Models {

    [DisplayName("Permission")]
    public class PermissionDTO {

        public PermissionDTO() {
            this.Key = "";
            this.Value = "";
        }

        public string Key { get; set; }

        public string Value { get; set; }

    
    }
}
