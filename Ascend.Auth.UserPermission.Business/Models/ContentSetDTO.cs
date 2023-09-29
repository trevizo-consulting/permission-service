
using System.ComponentModel;


namespace Ascend.Auth.UserPermission.Business.Models {

    [DisplayName("ContentSet")]
    public class ContentSetDTO {

        public string? DisplayName { get; set; } = null;
        public string? Identifier { get; set; } = null;
        public string? Type { get; set; } = null;

        public ContentSetDTO()
        {

        }

    }
}
