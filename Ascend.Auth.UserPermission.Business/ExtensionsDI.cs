using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascend.Auth.UserPermission.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.UserPermission.Business.Extensions {

    public static class DependencyInjectionExtensions {
        public static void AddUPDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContextPool<UserPermissionContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }
}
