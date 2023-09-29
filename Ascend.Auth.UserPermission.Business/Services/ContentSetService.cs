using Ascend.Auth.UserPermission.Business.Models;
using Ascend.Auth.UserPermission.Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascend.Auth.UserPermission.Business.Services {
    public class ContentSetService : IContentSetService {

        private IPermissionService _permissionService;
        private ILogger<ContentSetService> _logger;

        public ContentSetService(IPermissionService permissionService, ILogger<ContentSetService> logger) {
            _permissionService = permissionService;
            _logger = logger;
        }

        public async Task<IList<ContentSetDTO>> GetPermissions() {

            var key = "content.course-builder.content-sets"; // magic key for content sets

            IList<PermissionDTO> permissions = await _permissionService.GetByKey(key);
            // should only be one JSON array record
            if(permissions.Count > 1 )
            {
                throw new Exception(string.Format("Error in permission serialization. Key {0} Value {1}", key, permissions));
            }

            return permissions.Single().ToConentSet();

        }

    }
}
