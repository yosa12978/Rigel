using System.Globalization;
namespace Rigel.Dtos.Response
{
    public class PageDto<T> where T : class
    {
        public int PageIndex { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
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
        public List<T> Items { get; private set; } = default!;
        
        public PageDto(IEnumerable<T> items, int PageIndex, int TotalCount, int PageSize, int TotalPages) {
            this.PageIndex = PageIndex;
            this.TotalCount = TotalCount;
            this.PageSize = PageSize;
            this.TotalPages = TotalPages;
            this.Items = Items;
        }

    }
}