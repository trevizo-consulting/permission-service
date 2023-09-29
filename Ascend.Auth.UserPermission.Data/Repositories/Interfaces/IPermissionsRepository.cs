using Ascend.Auth.UserPermission.Data.Entities;
using System.Linq.Expressions;

namespace Ascend.Auth.UserPermission.Data.Repositories.Interfaces
{

    public interface IPermissionsRepository
    {

        IQueryable<Permission> GetByKey(string key);

        IQueryable<Permission> GetAll();

        IQueryable<Permission> Search(Expression<Func<Permission, bool>> whereClause);
    }

}
