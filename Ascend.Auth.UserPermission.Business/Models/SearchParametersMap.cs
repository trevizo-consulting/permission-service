using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ascend.Auth.UserPermission.Data.Entities;

namespace Ascend.Auth.UserPermission.Business.Models {
    public static class SearchParametersMap {


        public static BinaryExpression? GetJsonValueCompareExpression(MemberExpression p, string selector, string value) {

            var s = Expression.Constant(selector);
            var v = Expression.Constant(value);

            MethodInfo? methodInfo = typeof(UserPermissionContext).GetMethod("JsonValue");

            if(methodInfo == null) { throw new ArgumentException("JsonValue method not found"); }

            var jbody = Expression.Call(methodInfo, p, s);

            var body = Expression.Equal(jbody, v);


            return body;
        }

        public static Expression<Func<Permission, bool>> ToEntityPredicate(this FilterParametersDTO searchParameters) {

            Expression<Func<Permission, bool>>? finalLambda = null;

            try
            {
                Expression? whereClause = null;
                
                var functionParam = Expression.Parameter(typeof(Permission), "x");
                var p = Expression.Property(functionParam, "Value");

                foreach (ValueCompareExpressionDTO paramPredicate in searchParameters.Predicates)
                {
                    if (paramPredicate.Selector != null && paramPredicate.Value != null)
                    {
                        var predicate = GetJsonValueCompareExpression(p, paramPredicate.Selector, paramPredicate.Value);

                        if (predicate != null)
                        {
                            if (whereClause == null)
                                whereClause = predicate;
                            else
                                whereClause = Expression.AndAlso(whereClause, predicate);
                        }

                    }
                }

                if(whereClause != null)
                {
                    finalLambda = Expression.Lambda<Func<Permission, bool>>(whereClause, functionParam); ;
                }


            }
            catch (Exception)
            {

                finalLambda = null;
            }

            if (finalLambda == null)
                throw new ArgumentException("Error parsing search parameters");

            return finalLambda;
        }
    }
}
