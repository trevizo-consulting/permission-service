using Ascend.Auth.UserPermission.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascend.Auth.UserPermission.Business.Services.Interfaces {
    public interface IContentSetService {

        Task<IList<ContentSetDTO>> GetPermissions();
    }

    public enum Types {
        Course,
        Assessment,
        FlashCard,
        eBook,
        Pages
    }

}
