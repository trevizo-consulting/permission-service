using Ascend.Auth.UserPermission.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascend.Auth.UserPermission.Business.Services.Interfaces {
    public interface IPermissionService {

        Task<IList<PermissionDTO>> GetByKey(string? key);

        Task<IList<PermissionDTO>> GetAll();

        Task<IList<PermissionDTO>> Search(FilterParametersDTO parameters);


    }
}
