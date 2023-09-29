using System.ComponentModel;

namespace Ascend.Auth.UserPermission.Business.Models {


    /// <summary>
    /// This is a binary equality expression that will compare the value in the parameter with the JSON query selector.
    /// This expression will be applied to the value part of the key/value pair of the permission
    /// </summary>
    [DisplayName("ValueCompareExpression")]
    public class ValueCompareExpressionDTO {

        public string? Value { get; set; } = null;
        public string? Selector { get; set; } = null;

    }
}
