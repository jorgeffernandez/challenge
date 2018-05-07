using System;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Challenge.Infraestructure.Core
{
    public static class ObjectSetExtensions
    {
        public static IQueryable<TEntity> Paginate<TEntity, S>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, S>> orderBy,
            int pageIndex, int pageCount, bool ascending, Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            ObjectQuery<TEntity> query = queryable as ObjectQuery<TEntity>;

            if (query != null)
            {
                string orderPath = AnalyzeExpressionPath(orderBy);

                if (filter != null)
                    return query.Skip(string.Format(CultureInfo.InvariantCulture, "it.{0} {1}", orderPath, (ascending) ? "asc" : "desc"), "@skip", new ObjectParameter("skip", (pageIndex) * pageCount))
                        .Top("@limit", new ObjectParameter("limit", pageCount));
                else
                    return query.Skip(string.Format(CultureInfo.InvariantCulture, "it.{0} {1}", orderPath, (ascending) ? "asc" : "desc"), "@skip", new ObjectParameter("skip", (pageIndex) * pageCount))
                            .Top("@limit", new ObjectParameter("limit", pageCount))
                            .Where(filter);
            }
            else
                return queryable.OrderBy(orderBy).Skip((pageIndex * pageCount)).Take(pageCount);
        }

        #region Private Methods

        static string AnalyzeExpressionPath<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> expression)
            where TEntity : class
        {
            MemberExpression body = expression.Body as MemberExpression;
            if (((body == null) ||
                 !body.Member.DeclaringType.IsAssignableFrom(typeof(TEntity))) ||
                (body.Expression.NodeType != ExpressionType.Parameter))
            {
                throw new ArgumentException();
            }
            else
                return body.Member.Name;
        }

        #endregion
    }
}
