using CleanArchitectureDDD.Core.Common;
using CleanArchitectureDDD.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDDD.Infrastructure.Data
{
    public class SpecificationEvaluatOr<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
        {
            var Query = inputQuery.AsQueryable();

            if (spec.Criteria != null)
                Query = Query.Where(spec.Criteria);

            if (spec.OrderBy != null)
                Query = Query.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                Query = Query.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPagingEnabled)
                Query = Query.Skip(spec.Skip).Take(spec.Take);

            Query = spec.Includes.Aggregate(Query, (current, include) => current.Include(include));

            return Query;
        }
    }
}
