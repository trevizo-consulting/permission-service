using System.ComponentModel;

namespace Ascend.Auth.UserPermission.Business.Models {

    /// <summary>
    /// Parameters that define any predicates to apply as a filter to the permission query.
    /// </summary>
    [DisplayName("FilterParameters")]
    public class FilterParametersDTO {

        /// <summary>
        /// This is a list of expressions that will be combined together using the logical AND operator to form a predicate for this permission query request
        /// </summary>
        public List<ValueCompareExpressionDTO> Predicates {  get; set; }
        
        public FilterParametersDTO() {
            Predicates = new List<ValueCompareExpressionDTO> {  };
        }
        
    }

}
