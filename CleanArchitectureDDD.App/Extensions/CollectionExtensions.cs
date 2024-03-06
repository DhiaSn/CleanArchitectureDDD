namespace CleanArchitectureDDD.App.Extensions
{
    public static class CollectionExtensions
    {
        #region ToCastedList
        public static List<L> ToCastedList<T, L>(this IEnumerable<T> list, Func<T, L> enscabulate)
        {
            List<L> result = [];
            if (list != null)
                foreach (var item in list)
                    result.Add(enscabulate(item));
            return result;
        }
        public static async Task<List<L>> ToCastedList<T, L>(this IEnumerable<T> list, Func<T, Task<L>> enscabulate)
        {
            List<L> result = [];
            if (list != null)
                foreach (var item in list)
                    result.Add(await enscabulate(item));
            return result;
        }
        #endregion
    }
}
