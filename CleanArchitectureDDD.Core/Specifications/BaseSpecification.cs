using System.Linq.Expressions;

namespace CleanArchitectureDDD.Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        #region Variables 
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = [];
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }
        #endregion

        #region Constructor
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        #endregion

        #region Methods 
        public void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);
        public void AddOrderBy(Expression<Func<T, object>> OrderByexpression) => OrderBy = OrderByexpression;
        public void AddOrderByDecending(Expression<Func<T, object>> OrderByDecending) => OrderByDescending = OrderByDecending;
        public void ApplyPagging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
        #endregion
    }
}
