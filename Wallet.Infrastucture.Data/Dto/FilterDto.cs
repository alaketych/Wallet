using Microsoft.Extensions.Options;

namespace Wallet.Infrastucture.Data.Dto
{
	public class FilterDto
	{
		private readonly IOptions<PageSettings> _pageSettings;

		public int PageNumber { get; set; }

		public int PageSize { get; set; }

		public FilterDto()
		{
			PageNumber = 1;
			PageSize = 12;
		}

		public FilterDto(IOptions<PageSettings> pageSettings)
		{
			_pageSettings = pageSettings;
			PageNumber = _pageSettings.Value.PageNumber;
			PageSize = _pageSettings.Value.PageSize;
		}
	}
}
