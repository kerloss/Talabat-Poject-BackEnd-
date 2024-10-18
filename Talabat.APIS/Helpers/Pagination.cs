using Talabat.APIS.DTOs;

namespace Talabat.APIS.Helpers
{
	public class Pagination<T>
	{
		public Pagination(int pageSize, int pageIndex, int count,IReadOnlyList<T> mappedData)
		{
			PageSize = pageSize;
			PageIndex = pageIndex;
			Data = mappedData;
			Count = count;
		}

		public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
		public IReadOnlyList<T> Data { get; set; }
    }
}
