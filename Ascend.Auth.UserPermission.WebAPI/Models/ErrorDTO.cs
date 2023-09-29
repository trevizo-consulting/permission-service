using System.ComponentModel;

namespace Ascend.Auth.UserPermission.WebAPI.Models {

    [DisplayName("Error")]
    public class ErrorDTO {
        /// <summary>
        /// Internal debug code
        /// </summary>
        public string TraceId { get; set; } = "";
        /// <summary>
        /// Friendly message of the error
        /// </summary>
        public string Message { get; set; } = "";

    }
}
