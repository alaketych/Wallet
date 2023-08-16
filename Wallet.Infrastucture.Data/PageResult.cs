﻿namespace Wallet.Infrastucture.Data
{
	public class PageResult<T>
	{
		public int PageNumber { get; set; }

		public int PageSize { get; set; }

		public int TotalRecords { get; set; }

		public IList<T> Data { get; set; }

		public PageResult(IList<T> data, int pageNumber, int pageSize, int totalRecords)
		{
			Data = data;
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalRecords = totalRecords;
		}
	}
}
