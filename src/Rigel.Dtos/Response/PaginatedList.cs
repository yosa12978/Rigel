namespace Rigel.Dtos.Response
{
    public class PaginatedList<T> where T : class
    {
        public int PageIndex { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; private set; } = default!;

        public PaginatedList(IEnumerable<T> source, int pageIndex = 1, int pageSize = 30) {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int) Math.Ceiling(TotalCount / (double)PageSize);

            Items.AddRange(source.Skip((PageIndex-1) * PageSize).Take(PageSize));
        }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex < TotalPages);
            }
        }
    }
}