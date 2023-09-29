using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascend.Auth.UserPermission.Data.Entities;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Reflection;
using Ascend.Auth.UserPermission.Data.Repositories.Interfaces;

namespace Ascend.Auth.UserPermission.Data.Repositories
{

    public class PermissionsRepository : IPermissionsRepository {

        private UserPermissionContext _context;

        public PermissionsRepository(UserPermissionContext context)
        {
            _context = context;
        }

        public IQueryable<Permission> GetByKey(string key)
        {

            var query = _context.Permissions.Where(x => x.Key.KeyValue == key).GroupBy(x => x.Key).Select(g => new Permission { Key = new Key { KeyValue = g.Key.KeyValue } , Value = "[" + string.Join(",", g.Select( x=> x.Value)) + "]"  });

            return query;

        }

        public IQueryable<Permission> GetAll() {
            var query = from p in _context.Permissions select p;
            return query;
        }

        

        public IQueryable<Permission> Search(Expression<Func<Permission,bool>> whereClause) {

            //var query = _context.Permissions.Where((x) => UserPermissionContext.JsonValue(x.Value, "$.Identifier") == "CNC");


            return _context.Permissions.Where(whereClause);

        }

    }
}
