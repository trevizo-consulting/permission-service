using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.SqlServer.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Ascend.Auth.UserPermission.Data.Entities {
    public partial class UserPermissionContext : DbContext {

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {

            modelBuilder.HasDbFunction(typeof(UserPermissionContext).GetMethod(nameof(JsonValue))!
            ).HasName("JSON_VALUE").IsBuiltIn();

            modelBuilder.HasDbFunction(
                typeof(UserPermissionContext).GetMethod(nameof(JsonQuery))!
            ).HasName("JSON_QUERY").IsBuiltIn();

        }

        public static string JsonValue(string column, [NotParameterized] string path)
            => throw new NotSupportedException();

        public static string JsonQuery(string column, [NotParameterized] string path) =>
            throw new NotSupportedException();


    }


}
