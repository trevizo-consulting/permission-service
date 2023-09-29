using Ascend.Auth.UserPermission.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascend.Auth.UserPermission.Business.Models;
using System.Text.Json;

namespace Ascend.Auth.UserPermission.Business.Models {
    public static class ContentSetMap {

        public static IList<ContentSetDTO> ToConentSet(this PermissionDTO source)
        {
            IList<ContentSetDTO> contentSets = new List<ContentSetDTO>();

            if (source == null || source.Value == null) return contentSets;

            var deserializedCS = JsonSerializer.Deserialize<List<ContentSetDTO>>(source.Value) as List<ContentSetDTO>;
            
            if(deserializedCS != null) contentSets = deserializedCS;

            return contentSets;

        }
    }
}
