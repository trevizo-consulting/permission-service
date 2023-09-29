using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Ascend.Auth.UserPermission.Data;
using Microsoft.Extensions.Logging;
using Ascend.Auth.UserPermission.Business.Models;
using Ascend.Auth.UserPermission.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ascend.Auth.UserPermission.Data.Repositories.Interfaces;

namespace Ascend.Auth.UserPermission.Business.Services
{

    public class PermissionService : IPermissionService
    {

        private readonly ILogger<PermissionService> _logger;

        private readonly IPermissionsRepository _repo;

        public PermissionService(IPermissionsRepository repo, ILogger<PermissionService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IList<PermissionDTO>> GetByKey(string? key)
        {
            List<PermissionDTO> permissions = new List<PermissionDTO>();

            if(key != null)
            {
                return await _repo.GetByKey(key).Select( (p) => new PermissionDTO() { Key = p.Key.KeyValue, Value = p.Value  } ).ToListAsync();
            }

            return permissions;
        }

        public async Task<IList<PermissionDTO>> GetAll() {
             return await _repo.GetAll().Select((p) => new PermissionDTO() { Key = p.Key.KeyValue, Value = p.Value }).ToListAsync();
        }

        public async Task<IList<PermissionDTO>> Search(FilterParametersDTO parameters) {

            var linkPredicate = parameters.ToEntityPredicate();
            
            if (linkPredicate == null)
                throw new ArgumentException("Malformed search parameters");

            return await _repo.Search(linkPredicate).Select((p) => new PermissionDTO() { Key = p.Key.KeyValue, Value = p.Value }).ToListAsync();

        }
    }




}